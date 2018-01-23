
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/25/2017 14:56:02
-- Generated from EDMX file: E:\Exercise\Net\DDD\City_Repository\City_Repository\Entity\MyModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CityDB];
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

-- Creating table 'CitySet'
CREATE TABLE [dbo].[CitySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(max)  NOT NULL,
    [ZipCode] nvarchar(max)  NOT NULL,
    [Province_Id] int  NOT NULL
);
GO

-- Creating table 'ProvinceSet'
CREATE TABLE [dbo].[ProvinceSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProvinceName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DictTypeSet1'
CREATE TABLE [dbo].[DictTypeSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Remark] nvarchar(max)  NOT NULL,
    [Seq] nvarchar(max)  NOT NULL,
    [Editor] nvarchar(max)  NOT NULL,
    [LastUpdated] nvarchar(max)  NOT NULL,
    [PID] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CitySet'
ALTER TABLE [dbo].[CitySet]
ADD CONSTRAINT [PK_CitySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProvinceSet'
ALTER TABLE [dbo].[ProvinceSet]
ADD CONSTRAINT [PK_ProvinceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DictTypeSet1'
ALTER TABLE [dbo].[DictTypeSet1]
ADD CONSTRAINT [PK_DictTypeSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Province_Id] in table 'CitySet'
ALTER TABLE [dbo].[CitySet]
ADD CONSTRAINT [FK_ProvinceCity]
    FOREIGN KEY ([Province_Id])
    REFERENCES [dbo].[ProvinceSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvinceCity'
CREATE INDEX [IX_FK_ProvinceCity]
ON [dbo].[CitySet]
    ([Province_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------