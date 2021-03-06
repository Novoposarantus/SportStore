﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Moq;
using WebUI.Controllers;
using Domain.Abstract;
using System.Linq;
using System.Web.Mvc;
using WebUI.Infrastructure.Abstract;
using WebUI.Models;

namespace UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void CanEditProduct()
        {
            var mock = GetMock();
            var target = new AdminController(null,null);

            Product p1 = target.Edit(1).ViewData.Model as Product;
            Product p2 = target.Edit(2).ViewData.Model as Product;
            Product p3 = target.Edit(3).ViewData.Model as Product;

            Assert.AreEqual(1, p1.ProductID);
            Assert.AreEqual(2, p2.ProductID);
            Assert.AreEqual(3, p3.ProductID);
        }
        [TestMethod]
        public void CannotEditNonexistentProduct()
        {
            var mock = GetMock();
            var target = new AdminController(mock.Object,null);

            Product result = (Product)target.Edit(4).ViewData.Model;

            Assert.IsNull(result);
        }
        [TestMethod]
        public void CanSaveValidChanges()
        {
            var mock = new Mock<IProductRepository>();
            var target = new AdminController(mock.Object, null);
            var product = new Product { Name = "Test" };

            ActionResult result = target.EditProduct(product);

            mock.Verify(m => m.SaveProduct(product));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void CannotSaveInvalidChanges()
        {
            var mock = new Mock<IProductRepository>();
            var target = new AdminController(mock.Object, null);
            var product = new Product { Name = "Test" };
            target.ModelState.AddModelError("error", "error");

            ActionResult result = target.EditProduct(product);

            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            var mock = GetMock();
            var target = new AdminController(null,null);

            target.Delete(2);

            mock.Verify(m => m.DeleteProduct(2));
        }
        Mock<IProductRepository> GetMock()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
            });
            return mock;
        }
        [TestMethod]
        public void CanLoginWithValidCredentials()
        {
            var target = new AccountController();

            ActionResult result = target.Login();

            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyURL", ((RedirectResult)result).Url);
        }
        [TestMethod]
        public void CannotLoginWithInvalidCredentials()
        {
            var target = new AccountController();

            ActionResult result = target.Login();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}
