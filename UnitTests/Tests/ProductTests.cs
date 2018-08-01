using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Mvc;
using Domain.Abstract;
using WebUI.Controllers;
using WebUI.Models;
using WebUI.HtmlHelpers;
using Domain.Entities;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanPaginate()
        {
            var mock = GenerateMock();
            ProductController controller = new ProductController(mock.Object);

            Product[] result = ((ProductsListViewModel)controller.List(null,2).Model).Products.ToArray();
            
            Assert.IsTrue(result.Length == 1);
            Assert.AreEqual(result[0].Name, "P5");
        }
        [TestMethod]
        public void CanGeneratePageLinks()
        {
            HtmlHelper myHelper = null;
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };
            Func<int, string> pageUrlDelegate = i => $"Page{i}";

            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" +
                 @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" +
                @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }
        [TestMethod]
        public void CanSendPaginationViewModel()
        {
            var mock = GenerateMock();
            ProductController controller = new ProductController(mock.Object);

            ProductsListViewModel result = (ProductsListViewModel)controller.List(null,2).Model;

            PagingInfo pagingInfo = result.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage, 2);
            Assert.AreEqual(pagingInfo.ItemsPerPage, 4);
            Assert.AreEqual(pagingInfo.TotalItems, 5);
            Assert.AreEqual(pagingInfo.TotalPages, 2);
        }
        [TestMethod]
        public void CanFilterProducts()
        {
            var mock = GenerateMock();
            ProductController controller = new ProductController(mock.Object);

            Product[] result = ((ProductsListViewModel)controller.List("Apples", 1).Model).Products.ToArray();
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P1" && result[0].Category == "Apples");
            Assert.IsTrue(result[1].Name == "P2" && result[1].Category == "Apples");
        }
        [TestMethod]
        public void CanCreateCategories()
        {
            var mock = GenerateMock();
            NavController target = new NavController(mock.Object);
            
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();
            
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }
        [TestMethod]
        public void IndicatesSelectedCategory()
        {
            var mock = GenerateMock();
            NavController target = new NavController(mock.Object);
            string categoryToSelect = "Apples";

            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            Assert.AreEqual(categoryToSelect, result);
        }
        [TestMethod]
        public void GenerateCategorySpecificProductCount()
        {
            var mock = GenerateMock();
            ProductController target = new ProductController(mock.Object);

            int resApples = ((ProductsListViewModel)(target.List("Apples",1,null).Model)).PagingInfo.TotalItems;
            int resPlums = ((ProductsListViewModel)(target.List("Plums", 1, null).Model)).PagingInfo.TotalItems;
            int resOranges = ((ProductsListViewModel)(target.List("Oranges", 1, null).Model)).PagingInfo.TotalItems;
            int resAll = ((ProductsListViewModel)(target.List(null, 1, null).Model)).PagingInfo.TotalItems;

            Assert.AreEqual(resApples, 2);
            Assert.AreEqual(resPlums, 1);
            Assert.AreEqual(resOranges, 2);
            Assert.AreEqual(resAll, 5);
        }
        [TestMethod]
        public void FindByName()
        {
            var mock = GenerateMock();
            ProductController target = new ProductController(mock.Object);
            
            int result_p = ((ProductsListViewModel)(target.List(null, 1, "p").Model)).PagingInfo.TotalItems;
            int result_P = ((ProductsListViewModel)(target.List(null, 1, "P").Model)).PagingInfo.TotalItems;
            int result_4 = ((ProductsListViewModel)(target.List(null, 1, "4").Model)).PagingInfo.TotalItems;
            int result_emptyString = ((ProductsListViewModel)(target.List(null, 1, "").Model)).PagingInfo.TotalItems;
            int result_NooneContains = ((ProductsListViewModel)(target.List(null, 1, "3l12hbe1h").Model)).PagingInfo.TotalItems;
            int result_Null = ((ProductsListViewModel)(target.List(null, 1, null).Model)).PagingInfo.TotalItems;
            
            Assert.AreEqual(result_p, 5);
            Assert.AreEqual(result_P, 5);
            Assert.AreEqual(result_4, 1);
            Assert.AreEqual(result_emptyString, 5);
            Assert.AreEqual(result_NooneContains, 0);
            Assert.AreEqual(result_Null, 5);
        }
        [TestMethod]
        public void FindInDescription()
        {
            var mock = GenerateMock();
            ProductController target = new ProductController(mock.Object);

            int result_One = ((ProductsListViewModel)(target.List(null, 1, "One", true).Model)).PagingInfo.TotalItems;
            int result_T = ((ProductsListViewModel)(target.List(null, 1, "T", true).Model)).PagingInfo.TotalItems;
            int result_emptyString = ((ProductsListViewModel)(target.List(null, 1, "", true).Model)).PagingInfo.TotalItems;
            int result_NooneContains = ((ProductsListViewModel)(target.List(null, 1, "3l12hbe1h", true).Model)).PagingInfo.TotalItems;
            int result_False = ((ProductsListViewModel)(target.List(null, 1, null, false).Model)).PagingInfo.TotalItems;

            Assert.AreEqual(result_One, 1);
            Assert.AreEqual(result_T, 2);
            Assert.AreEqual(result_emptyString, 5);
            Assert.AreEqual(result_NooneContains, 0);
            Assert.AreEqual(result_False, 5);
        }
        [TestMethod]
        public void CanAddNewLines()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            CartLine[] result = target.Lines.ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Product, p1);
            Assert.AreEqual(result[1].Product, p2);

        }
        [TestMethod]
        public void CanAddLineWhenIsExist()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Cart target = new Cart();
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);

            target.AddItem(p1, 4);
            CartLine[] result = target.Lines.ToArray();

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0].Product, p1);
            Assert.AreEqual(result[0].Quantity, 5);

        }
        [TestMethod]
        public void CanRemoveLine()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };
            Cart target = new Cart();
            target.AddItem(p1, 8);
            target.AddItem(p2, 3);
            target.AddItem(p3, 4);

            target.RemoveLine(p2);

            Assert.AreEqual(target.Lines.Where(l => l.Product == p2).Count(), 0);
            Assert.AreEqual(target.Lines.Count(),2);
        }
        [TestMethod]
        public void CalculateCartTotal()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1" , Price = 100M};
            Product p2 = new Product { ProductID = 2, Name = "P2" , Price = 50M};
            Product p3 = new Product { ProductID = 3, Name = "P3" , Price = 10M};
            Cart target = new Cart();
            target.AddItem(p1, 3);
            target.AddItem(p2, 5);
            target.AddItem(p3, 3);

            decimal result = target.ComputeTotalValue();

            Assert.AreEqual(result, 580M);
        }
        [TestMethod]
        public void Can_Clear_Contents()
        {
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 10M };
            Cart target = new Cart();
            target.AddItem(p1, 3);
            target.AddItem(p2, 5);
            target.AddItem(p3, 3);

            target.Clear();

            Assert.AreEqual(target.Lines.Count(), 0);
        }

        Mock<IProductRepository> GenerateMock()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1",Description = "One", Category = "Apples"},
                new Product {ProductID = 2, Name = "P2",Description = "Two", Category = "Apples"},
                new Product {ProductID = 3, Name = "P3",Description = "Three", Category = "Plums"},
                new Product {ProductID = 4, Name = "P4",Description = "Four", Category = "Oranges"},
                new Product {ProductID = 4, Name = "P5",Description = "Five", Category = "Oranges"},
            });
            return mock;
        }
    }
}
