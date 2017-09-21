
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2017 12:25:31
-- Generated from EDMX file: E:\Studium\6. Semester\VWW\Hausarbeit\VWW_Project\Model\DbModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-VWW_Project-20170607022226];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventSet] DROP CONSTRAINT [FK_UserEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageSet1] DROP CONSTRAINT [FK_UserMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_UserMessage1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MessageSet1] DROP CONSTRAINT [FK_UserMessage1];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[EventSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventSet];
GO
IF OBJECT_ID(N'[dbo].[MessageSet1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MessageSet1];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] nvarchar(255)  NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [IsOnline] bit  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventSet'
CREATE TABLE [dbo].[EventSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Subject] nvarchar(100)  NOT NULL,
    [Description] nvarchar(300)  NULL,
    [Start] datetime  NOT NULL,
    [End] datetime  NULL,
    [ThemeColor] nvarchar(10)  NULL,
    [IsFullDay] bit  NOT NULL,
    [IsShared] bit  NOT NULL,
    [UserId] nvarchar(255)  NOT NULL
);
GO

-- Creating table 'MessageSet1'
CREATE TABLE [dbo].[MessageSet1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Time] datetime  NOT NULL,
    [FromUserId] nvarchar(255)  NOT NULL,
    [ToUserId] nvarchar(255)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EventSet'
ALTER TABLE [dbo].[EventSet]
ADD CONSTRAINT [PK_EventSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MessageSet1'
ALTER TABLE [dbo].[MessageSet1]
ADD CONSTRAINT [PK_MessageSet1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'EventSet'
ALTER TABLE [dbo].[EventSet]
ADD CONSTRAINT [FK_UserEvent]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserEvent'
CREATE INDEX [IX_FK_UserEvent]
ON [dbo].[EventSet]
    ([UserId]);
GO

-- Creating foreign key on [FromUserId] in table 'MessageSet1'
ALTER TABLE [dbo].[MessageSet1]
ADD CONSTRAINT [FK_UserMessage]
    FOREIGN KEY ([FromUserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessage'
CREATE INDEX [IX_FK_UserMessage]
ON [dbo].[MessageSet1]
    ([FromUserId]);
GO

-- Creating foreign key on [ToUserId] in table 'MessageSet1'
ALTER TABLE [dbo].[MessageSet1]
ADD CONSTRAINT [FK_UserMessage1]
    FOREIGN KEY ([ToUserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserMessage1'
CREATE INDEX [IX_FK_UserMessage1]
ON [dbo].[MessageSet1]
    ([ToUserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------