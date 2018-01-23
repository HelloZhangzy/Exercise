
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/20/2017 13:41:27
-- Generated from EDMX file: E:\Exercise\Net\DDD\SaleOrder\SaleOrder\SaleOrder.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SaleOrder];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerSet'
CREATE TABLE [dbo].[CustomerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoginName] nvarchar(max)  NOT NULL,
    [LoginPassword] nvarchar(max)  NOT NULL,
    [DayOfBirth] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [BillingAddress] nvarchar(max)  NOT NULL,
    [DeliveryAddress] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreatedDate] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'CreditCardSet'
CREATE TABLE [dbo].[CreditCardSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Holdername] nvarchar(max)  NOT NULL,
    [ExpirationDate] nvarchar(max)  NOT NULL,
    [Customer_Id] int  NOT NULL
);
GO

-- Creating table 'OrderLineSet'
CREATE TABLE [dbo].[OrderLineSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Quantity] nvarchar(max)  NOT NULL,
    [Discount] nvarchar(max)  NOT NULL,
    [Order_Id] int  NOT NULL,
    [Item_Id] int  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ItemSet'
CREATE TABLE [dbo].[ItemSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Purchaseprice] nvarchar(max)  NOT NULL,
    [SalesPrice] nvarchar(max)  NOT NULL,
    [Category_Id] int  NOT NULL
);
GO

-- Creating table 'OrderSet_SalesOrder'
CREATE TABLE [dbo].[OrderSet_SalesOrder] (
    [Shippingdate] nvarchar(max)  NOT NULL,
    [CancelDate] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [ReturnOrder_Id] int  NOT NULL
);
GO

-- Creating table 'OrderSet_ReturnOrder'
CREATE TABLE [dbo].[OrderSet_ReturnOrder] (
    [ReturnDate] nvarchar(max)  NOT NULL,
    [Reason] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CustomerSet'
ALTER TABLE [dbo].[CustomerSet]
ADD CONSTRAINT [PK_CustomerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CreditCardSet'
ALTER TABLE [dbo].[CreditCardSet]
ADD CONSTRAINT [PK_CreditCardSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderLineSet'
ALTER TABLE [dbo].[OrderLineSet]
ADD CONSTRAINT [PK_OrderLineSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ItemSet'
ALTER TABLE [dbo].[ItemSet]
ADD CONSTRAINT [PK_ItemSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet_SalesOrder'
ALTER TABLE [dbo].[OrderSet_SalesOrder]
ADD CONSTRAINT [PK_OrderSet_SalesOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet_ReturnOrder'
ALTER TABLE [dbo].[OrderSet_ReturnOrder]
ADD CONSTRAINT [PK_OrderSet_ReturnOrder]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Customer_Id] in table 'CreditCardSet'
ALTER TABLE [dbo].[CreditCardSet]
ADD CONSTRAINT [FK_CustomerCreditCard]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerCreditCard'
CREATE INDEX [IX_FK_CustomerCreditCard]
ON [dbo].[CreditCardSet]
    ([Customer_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[CustomerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[OrderSet]
    ([Customer_Id]);
GO

-- Creating foreign key on [ReturnOrder_Id] in table 'OrderSet_SalesOrder'
ALTER TABLE [dbo].[OrderSet_SalesOrder]
ADD CONSTRAINT [FK_SalesOrderReturnOrder]
    FOREIGN KEY ([ReturnOrder_Id])
    REFERENCES [dbo].[OrderSet_ReturnOrder]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalesOrderReturnOrder'
CREATE INDEX [IX_FK_SalesOrderReturnOrder]
ON [dbo].[OrderSet_SalesOrder]
    ([ReturnOrder_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderLineSet'
ALTER TABLE [dbo].[OrderLineSet]
ADD CONSTRAINT [FK_OrderOrderLine]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderLine'
CREATE INDEX [IX_FK_OrderOrderLine]
ON [dbo].[OrderLineSet]
    ([Order_Id]);
GO

-- Creating foreign key on [Item_Id] in table 'OrderLineSet'
ALTER TABLE [dbo].[OrderLineSet]
ADD CONSTRAINT [FK_OrderLineItem]
    FOREIGN KEY ([Item_Id])
    REFERENCES [dbo].[ItemSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderLineItem'
CREATE INDEX [IX_FK_OrderLineItem]
ON [dbo].[OrderLineSet]
    ([Item_Id]);
GO

-- Creating foreign key on [Category_Id] in table 'ItemSet'
ALTER TABLE [dbo].[ItemSet]
ADD CONSTRAINT [FK_CategoryItem]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryItem'
CREATE INDEX [IX_FK_CategoryItem]
ON [dbo].[ItemSet]
    ([Category_Id]);
GO

-- Creating foreign key on [Id] in table 'OrderSet_SalesOrder'
ALTER TABLE [dbo].[OrderSet_SalesOrder]
ADD CONSTRAINT [FK_SalesOrder_inherits_Order]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'OrderSet_ReturnOrder'
ALTER TABLE [dbo].[OrderSet_ReturnOrder]
ADD CONSTRAINT [FK_ReturnOrder_inherits_Order]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[OrderSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------