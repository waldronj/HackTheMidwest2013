
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/15/2013 20:28:35
-- Generated from EDMX file: C:\Users\tstivers\Documents\Visual Studio 2012\Projects\HackTheMidwest2013\HackMW2013\HackMW2013\Models\CallingTreeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [hackMW];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TreeOwner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trees] DROP CONSTRAINT [FK_TreeOwner];
GO
IF OBJECT_ID(N'[dbo].[FK_TreeChat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Chats] DROP CONSTRAINT [FK_TreeChat];
GO
IF OBJECT_ID(N'[dbo].[FK_ChatMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Chats] DROP CONSTRAINT [FK_ChatMember];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO
IF OBJECT_ID(N'[dbo].[Chats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Chats];
GO
IF OBJECT_ID(N'[dbo].[Trees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trees];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(300)  NOT NULL,
    [PhoneNumber] nvarchar(16)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [TreeId] int  NOT NULL
);
GO

-- Creating table 'Chats'
CREATE TABLE [dbo].[Chats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Messege] nvarchar(max)  NOT NULL,
    [TimeStamp] time  NOT NULL,
    [TreeId] int  NOT NULL,
    [MemberId] int  NOT NULL
);
GO

-- Creating table 'Trees'
CREATE TABLE [dbo].[Trees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [OwnerId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [PK_Chats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Trees'
ALTER TABLE [dbo].[Trees]
ADD CONSTRAINT [PK_Trees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TreeId] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [FK_TreeChat]
    FOREIGN KEY ([TreeId])
    REFERENCES [dbo].[Trees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TreeChat'
CREATE INDEX [IX_FK_TreeChat]
ON [dbo].[Chats]
    ([TreeId]);
GO

-- Creating foreign key on [MemberId] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [FK_ChatMember]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatMember'
CREATE INDEX [IX_FK_ChatMember]
ON [dbo].[Chats]
    ([MemberId]);
GO

-- Creating foreign key on [TreeId] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [FK_TreeMember]
    FOREIGN KEY ([TreeId])
    REFERENCES [dbo].[Trees]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TreeMember'
CREATE INDEX [IX_FK_TreeMember]
ON [dbo].[Members]
    ([TreeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------