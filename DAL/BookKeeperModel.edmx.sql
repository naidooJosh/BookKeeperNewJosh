
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/23/2019 10:00:14
-- Generated from EDMX file: C:\Users\Joshua\source\repos\BookKeeperNewJosh\DAL\BookKeeperModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BookKeeper];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BookListings_Module1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookListings] DROP CONSTRAINT [FK_BookListings_Module1];
GO
IF OBJECT_ID(N'[dbo].[FK_BookListings_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookListings] DROP CONSTRAINT [FK_BookListings_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Cart_BookListings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_BookListings];
GO
IF OBJECT_ID(N'[dbo].[FK_Cart_CartStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_CartStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Cart_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cart] DROP CONSTRAINT [FK_Cart_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_MemberRole_MemberRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberRole] DROP CONSTRAINT [FK_MemberRole_MemberRole];
GO
IF OBJECT_ID(N'[dbo].[FK_MemberRole_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberRole] DROP CONSTRAINT [FK_MemberRole_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_ShippingDetails_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ShippingDetails] DROP CONSTRAINT [FK_ShippingDetails_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDepartments_Departments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDepartments] DROP CONSTRAINT [FK_UserDepartments_Departments];
GO
IF OBJECT_ID(N'[dbo].[FK_UserDepartments_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserDepartments] DROP CONSTRAINT [FK_UserDepartments_Users];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[BookListings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookListings];
GO
IF OBJECT_ID(N'[dbo].[Cart]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cart];
GO
IF OBJECT_ID(N'[dbo].[CartStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CartStatus];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[MemberRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemberRole];
GO
IF OBJECT_ID(N'[dbo].[Module]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Module];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[ShippingDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ShippingDetails];
GO
IF OBJECT_ID(N'[dbo].[SlideImage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SlideImage];
GO
IF OBJECT_ID(N'[dbo].[UserDepartments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserDepartments];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [userName] nchar(20)  NOT NULL,
    [password] nchar(10)  NOT NULL
);
GO

-- Creating table 'BookListings'
CREATE TABLE [dbo].[BookListings] (
    [listingID] int IDENTITY(1,1) NOT NULL,
    [listedPrice] decimal(18,0)  NOT NULL,
    [soldPrice] decimal(18,0)  NOT NULL,
    [condition] int  NOT NULL,
    [title] nvarchar(max)  NOT NULL,
    [author] nvarchar(max)  NOT NULL,
    [studentNumber] int  NOT NULL,
    [moduleKey] int  NOT NULL,
    [photo] varbinary(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [isSold] bit  NOT NULL,
    [isQuickSell] bit  NOT NULL,
    [perDrop] real  NULL,
    [duration] int  NULL
);
GO

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [cartID] nchar(10)  NOT NULL,
    [listingID] int  NOT NULL,
    [studentNo] int  NOT NULL,
    [cartStatusID] nchar(10)  NOT NULL
);
GO

-- Creating table 'CartStatus'
CREATE TABLE [dbo].[CartStatus] (
    [cartStatusID] nchar(10)  NOT NULL,
    [cartStatus] varchar(500)  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [departmentID] int  NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'MemberRoles'
CREATE TABLE [dbo].[MemberRoles] (
    [memberRoleID] nchar(10)  NOT NULL,
    [studentNo] nchar(10)  NOT NULL,
    [roleID] nchar(10)  NOT NULL
);
GO

-- Creating table 'Modules'
CREATE TABLE [dbo].[Modules] (
    [moduleKey] int  NOT NULL,
    [moduleCode] nchar(10)  NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleId] nchar(10)  NOT NULL,
    [RoleName] varchar(50)  NOT NULL
);
GO

-- Creating table 'ShippingDetails'
CREATE TABLE [dbo].[ShippingDetails] (
    [shippingDetailID] nchar(10)  NOT NULL,
    [studentNo] int  NOT NULL,
    [address] varchar(500)  NOT NULL,
    [city] varchar(500)  NOT NULL,
    [state] varchar(500)  NOT NULL,
    [country] varchar(50)  NOT NULL,
    [zipCode] varchar(50)  NOT NULL,
    [orderID] int  NOT NULL,
    [amountPaid] decimal(18,0)  NOT NULL,
    [paymentType] varchar(50)  NOT NULL
);
GO

-- Creating table 'SlideImages'
CREATE TABLE [dbo].[SlideImages] (
    [slideID] nchar(10)  NOT NULL,
    [slideTitle] varchar(500)  NOT NULL,
    [slideImage1] varbinary(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [studentNo] int  NOT NULL,
    [fName] nchar(20)  NULL,
    [lName] nchar(20)  NOT NULL,
    [password] varchar(50)  NOT NULL,
    [isBlacklisted] bit  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [totalrating] int  NOT NULL,
    [ratingcount] int  NOT NULL,
    [blacklistReason] nvarchar(max)  NULL,
    [appealed] bit  NULL
);
GO

-- Creating table 'UserDepartments'
CREATE TABLE [dbo].[UserDepartments] (
    [Departments_departmentID] int  NOT NULL,
    [Users_studentNo] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [userName] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([userName] ASC);
GO

-- Creating primary key on [listingID] in table 'BookListings'
ALTER TABLE [dbo].[BookListings]
ADD CONSTRAINT [PK_BookListings]
    PRIMARY KEY CLUSTERED ([listingID] ASC);
GO

-- Creating primary key on [cartID] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([cartID] ASC);
GO

-- Creating primary key on [cartStatusID] in table 'CartStatus'
ALTER TABLE [dbo].[CartStatus]
ADD CONSTRAINT [PK_CartStatus]
    PRIMARY KEY CLUSTERED ([cartStatusID] ASC);
GO

-- Creating primary key on [departmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([departmentID] ASC);
GO

-- Creating primary key on [memberRoleID] in table 'MemberRoles'
ALTER TABLE [dbo].[MemberRoles]
ADD CONSTRAINT [PK_MemberRoles]
    PRIMARY KEY CLUSTERED ([memberRoleID] ASC);
GO

-- Creating primary key on [moduleKey] in table 'Modules'
ALTER TABLE [dbo].[Modules]
ADD CONSTRAINT [PK_Modules]
    PRIMARY KEY CLUSTERED ([moduleKey] ASC);
GO

-- Creating primary key on [RoleId] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [shippingDetailID] in table 'ShippingDetails'
ALTER TABLE [dbo].[ShippingDetails]
ADD CONSTRAINT [PK_ShippingDetails]
    PRIMARY KEY CLUSTERED ([shippingDetailID] ASC);
GO

-- Creating primary key on [slideID] in table 'SlideImages'
ALTER TABLE [dbo].[SlideImages]
ADD CONSTRAINT [PK_SlideImages]
    PRIMARY KEY CLUSTERED ([slideID] ASC);
GO

-- Creating primary key on [studentNo] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([studentNo] ASC);
GO

-- Creating primary key on [Departments_departmentID], [Users_studentNo] in table 'UserDepartments'
ALTER TABLE [dbo].[UserDepartments]
ADD CONSTRAINT [PK_UserDepartments]
    PRIMARY KEY CLUSTERED ([Departments_departmentID], [Users_studentNo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [moduleKey] in table 'BookListings'
ALTER TABLE [dbo].[BookListings]
ADD CONSTRAINT [FK_BookListings_Module1]
    FOREIGN KEY ([moduleKey])
    REFERENCES [dbo].[Modules]
        ([moduleKey])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookListings_Module1'
CREATE INDEX [IX_FK_BookListings_Module1]
ON [dbo].[BookListings]
    ([moduleKey]);
GO

-- Creating foreign key on [studentNumber] in table 'BookListings'
ALTER TABLE [dbo].[BookListings]
ADD CONSTRAINT [FK_BookListings_Users]
    FOREIGN KEY ([studentNumber])
    REFERENCES [dbo].[Users]
        ([studentNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookListings_Users'
CREATE INDEX [IX_FK_BookListings_Users]
ON [dbo].[BookListings]
    ([studentNumber]);
GO

-- Creating foreign key on [listingID] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_BookListings]
    FOREIGN KEY ([listingID])
    REFERENCES [dbo].[BookListings]
        ([listingID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_BookListings'
CREATE INDEX [IX_FK_Cart_BookListings]
ON [dbo].[Carts]
    ([listingID]);
GO

-- Creating foreign key on [cartStatusID] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_CartStatus]
    FOREIGN KEY ([cartStatusID])
    REFERENCES [dbo].[CartStatus]
        ([cartStatusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_CartStatus'
CREATE INDEX [IX_FK_Cart_CartStatus]
ON [dbo].[Carts]
    ([cartStatusID]);
GO

-- Creating foreign key on [studentNo] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_Cart_Users]
    FOREIGN KEY ([studentNo])
    REFERENCES [dbo].[Users]
        ([studentNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Cart_Users'
CREATE INDEX [IX_FK_Cart_Users]
ON [dbo].[Carts]
    ([studentNo]);
GO

-- Creating foreign key on [memberRoleID] in table 'MemberRoles'
ALTER TABLE [dbo].[MemberRoles]
ADD CONSTRAINT [FK_MemberRole_MemberRole]
    FOREIGN KEY ([memberRoleID])
    REFERENCES [dbo].[MemberRoles]
        ([memberRoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [roleID] in table 'MemberRoles'
ALTER TABLE [dbo].[MemberRoles]
ADD CONSTRAINT [FK_MemberRole_Roles]
    FOREIGN KEY ([roleID])
    REFERENCES [dbo].[Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberRole_Roles'
CREATE INDEX [IX_FK_MemberRole_Roles]
ON [dbo].[MemberRoles]
    ([roleID]);
GO

-- Creating foreign key on [studentNo] in table 'ShippingDetails'
ALTER TABLE [dbo].[ShippingDetails]
ADD CONSTRAINT [FK_ShippingDetails_Users]
    FOREIGN KEY ([studentNo])
    REFERENCES [dbo].[Users]
        ([studentNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ShippingDetails_Users'
CREATE INDEX [IX_FK_ShippingDetails_Users]
ON [dbo].[ShippingDetails]
    ([studentNo]);
GO

-- Creating foreign key on [Departments_departmentID] in table 'UserDepartments'
ALTER TABLE [dbo].[UserDepartments]
ADD CONSTRAINT [FK_UserDepartments_Departments]
    FOREIGN KEY ([Departments_departmentID])
    REFERENCES [dbo].[Departments]
        ([departmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_studentNo] in table 'UserDepartments'
ALTER TABLE [dbo].[UserDepartments]
ADD CONSTRAINT [FK_UserDepartments_Users]
    FOREIGN KEY ([Users_studentNo])
    REFERENCES [dbo].[Users]
        ([studentNo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserDepartments_Users'
CREATE INDEX [IX_FK_UserDepartments_Users]
ON [dbo].[UserDepartments]
    ([Users_studentNo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------