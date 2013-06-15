
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/15/2013 15:49:30
-- Generated from EDMX file: C:\Users\jwaldron\Documents\GitHub\HackTheMidwest2013\HackMW2013\HackMW2013\Models\CallingTreeModel.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TreeMembers'
CREATE TABLE [dbo].[TreeMembers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(300)  NOT NULL,
    [PhoneNumber] nvarchar(16)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [IsOwner] bit  NOT NULL
);
GO

-- Creating table 'TreeOwners'
CREATE TABLE [dbo].[TreeOwners] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TreeMemberID] int  NOT NULL,
    [OwnerID] nvarchar(max)  NOT NULL,
    [ListID] int  NOT NULL
);
GO

-- Creating table 'Chats'
CREATE TABLE [dbo].[Chats] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OwnerID] int  NOT NULL,
    [TreeID] int  NOT NULL,
    [TreeMemberID] int  NOT NULL,
    [Messege] nvarchar(max)  NOT NULL,
    [TimeStamp] time  NOT NULL,
    [TreeOwner_Id] int  NOT NULL
);
GO

-- Creating table 'TreeMemberTreeOwner'
CREATE TABLE [dbo].[TreeMemberTreeOwner] (
    [TreeMembers_Id] int  NOT NULL,
    [TreeOwners_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TreeMembers'
ALTER TABLE [dbo].[TreeMembers]
ADD CONSTRAINT [PK_TreeMembers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TreeOwners'
ALTER TABLE [dbo].[TreeOwners]
ADD CONSTRAINT [PK_TreeOwners]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [PK_Chats]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [TreeMembers_Id], [TreeOwners_Id] in table 'TreeMemberTreeOwner'
ALTER TABLE [dbo].[TreeMemberTreeOwner]
ADD CONSTRAINT [PK_TreeMemberTreeOwner]
    PRIMARY KEY NONCLUSTERED ([TreeMembers_Id], [TreeOwners_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TreeOwner_Id] in table 'Chats'
ALTER TABLE [dbo].[Chats]
ADD CONSTRAINT [FK_ChatTreeOwner]
    FOREIGN KEY ([TreeOwner_Id])
    REFERENCES [dbo].[TreeOwners]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChatTreeOwner'
CREATE INDEX [IX_FK_ChatTreeOwner]
ON [dbo].[Chats]
    ([TreeOwner_Id]);
GO

-- Creating foreign key on [TreeMembers_Id] in table 'TreeMemberTreeOwner'
ALTER TABLE [dbo].[TreeMemberTreeOwner]
ADD CONSTRAINT [FK_TreeMemberTreeOwner_TreeMember]
    FOREIGN KEY ([TreeMembers_Id])
    REFERENCES [dbo].[TreeMembers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TreeOwners_Id] in table 'TreeMemberTreeOwner'
ALTER TABLE [dbo].[TreeMemberTreeOwner]
ADD CONSTRAINT [FK_TreeMemberTreeOwner_TreeOwner]
    FOREIGN KEY ([TreeOwners_Id])
    REFERENCES [dbo].[TreeOwners]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TreeMemberTreeOwner_TreeOwner'
CREATE INDEX [IX_FK_TreeMemberTreeOwner_TreeOwner]
ON [dbo].[TreeMemberTreeOwner]
    ([TreeOwners_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------