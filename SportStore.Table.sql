CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(100) NOT NULL, 
    [Description] NCHAR(500) NOT NULL, 
    [Category] NCHAR(50) NOT NULL, 
    [Price] DECIMAL(16, 2) NOT NULL
)
