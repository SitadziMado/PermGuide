
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/18/2018 00:26:54
-- Generated from EDMX file: C:\Users\Максим\Documents\Visual Studio 2017\Projects\PermGuide\PermGuide\PermGuide.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PermGuide];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewRecordSet] DROP CONSTRAINT [FK_UserReview];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionSight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SightRecordSet] DROP CONSTRAINT [FK_RegionSight];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTimetable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimetableRecordSet] DROP CONSTRAINT [FK_UserTimetable];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileRecordSet] DROP CONSTRAINT [FK_ArticleFile];
GO
IF OBJECT_ID(N'[dbo].[FK_SightArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SightRecordSet] DROP CONSTRAINT [FK_SightArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionRecordSet] DROP CONSTRAINT [FK_RegionArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExcursionRecordSet] DROP CONSTRAINT [FK_ExcursionArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionSight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SightRecordSet] DROP CONSTRAINT [FK_ExcursionSight];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewRecordSet] DROP CONSTRAINT [FK_ExcursionReview];
GO
IF OBJECT_ID(N'[dbo].[FK_SightReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewRecordSet] DROP CONSTRAINT [FK_SightReview];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRecordSet];
GO
IF OBJECT_ID(N'[dbo].[ReviewRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReviewRecordSet];
GO
IF OBJECT_ID(N'[dbo].[FileRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileRecordSet];
GO
IF OBJECT_ID(N'[dbo].[SightRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SightRecordSet];
GO
IF OBJECT_ID(N'[dbo].[ArticleRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArticleRecordSet];
GO
IF OBJECT_ID(N'[dbo].[ExcursionRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExcursionRecordSet];
GO
IF OBJECT_ID(N'[dbo].[RegionRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionRecordSet];
GO
IF OBJECT_ID(N'[dbo].[TimetableRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimetableRecordSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserRecordSet'
CREATE TABLE [dbo].[UserRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ReviewRecordSet'
CREATE TABLE [dbo].[ReviewRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Mark] nvarchar(max)  NOT NULL,
    [User_Id] uniqueidentifier  NOT NULL,
    [Excursion_Id] uniqueidentifier  NOT NULL,
    [Sight_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'FileRecordSet'
CREATE TABLE [dbo].[FileRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [MediaType] nvarchar(max)  NOT NULL,
    [Article_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'SightRecordSet'
CREATE TABLE [dbo].[SightRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Location] geography  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Region_Id] uniqueidentifier  NOT NULL,
    [Article_Id] uniqueidentifier  NOT NULL,
    [Excursion_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'ArticleRecordSet'
CREATE TABLE [dbo].[ArticleRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ExcursionRecordSet'
CREATE TABLE [dbo].[ExcursionRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Article_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RegionRecordSet'
CREATE TABLE [dbo].[RegionRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Article_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'TimetableRecordSet'
CREATE TABLE [dbo].[TimetableRecordSet] (
    [Id] uniqueidentifier  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Activities] nvarchar(max)  NOT NULL,
    [User_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserRecordSet'
ALTER TABLE [dbo].[UserRecordSet]
ADD CONSTRAINT [PK_UserRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ReviewRecordSet'
ALTER TABLE [dbo].[ReviewRecordSet]
ADD CONSTRAINT [PK_ReviewRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileRecordSet'
ALTER TABLE [dbo].[FileRecordSet]
ADD CONSTRAINT [PK_FileRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SightRecordSet'
ALTER TABLE [dbo].[SightRecordSet]
ADD CONSTRAINT [PK_SightRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ArticleRecordSet'
ALTER TABLE [dbo].[ArticleRecordSet]
ADD CONSTRAINT [PK_ArticleRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExcursionRecordSet'
ALTER TABLE [dbo].[ExcursionRecordSet]
ADD CONSTRAINT [PK_ExcursionRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RegionRecordSet'
ALTER TABLE [dbo].[RegionRecordSet]
ADD CONSTRAINT [PK_RegionRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TimetableRecordSet'
ALTER TABLE [dbo].[TimetableRecordSet]
ADD CONSTRAINT [PK_TimetableRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'ReviewRecordSet'
ALTER TABLE [dbo].[ReviewRecordSet]
ADD CONSTRAINT [FK_UserReview]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReview'
CREATE INDEX [IX_FK_UserReview]
ON [dbo].[ReviewRecordSet]
    ([User_Id]);
GO

-- Creating foreign key on [Region_Id] in table 'SightRecordSet'
ALTER TABLE [dbo].[SightRecordSet]
ADD CONSTRAINT [FK_RegionSight]
    FOREIGN KEY ([Region_Id])
    REFERENCES [dbo].[RegionRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionSight'
CREATE INDEX [IX_FK_RegionSight]
ON [dbo].[SightRecordSet]
    ([Region_Id]);
GO

-- Creating foreign key on [User_Id] in table 'TimetableRecordSet'
ALTER TABLE [dbo].[TimetableRecordSet]
ADD CONSTRAINT [FK_UserTimetable]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTimetable'
CREATE INDEX [IX_FK_UserTimetable]
ON [dbo].[TimetableRecordSet]
    ([User_Id]);
GO

-- Creating foreign key on [Article_Id] in table 'FileRecordSet'
ALTER TABLE [dbo].[FileRecordSet]
ADD CONSTRAINT [FK_ArticleFile]
    FOREIGN KEY ([Article_Id])
    REFERENCES [dbo].[ArticleRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticleFile'
CREATE INDEX [IX_FK_ArticleFile]
ON [dbo].[FileRecordSet]
    ([Article_Id]);
GO

-- Creating foreign key on [Article_Id] in table 'SightRecordSet'
ALTER TABLE [dbo].[SightRecordSet]
ADD CONSTRAINT [FK_SightArticle]
    FOREIGN KEY ([Article_Id])
    REFERENCES [dbo].[ArticleRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SightArticle'
CREATE INDEX [IX_FK_SightArticle]
ON [dbo].[SightRecordSet]
    ([Article_Id]);
GO

-- Creating foreign key on [Article_Id] in table 'RegionRecordSet'
ALTER TABLE [dbo].[RegionRecordSet]
ADD CONSTRAINT [FK_RegionArticle]
    FOREIGN KEY ([Article_Id])
    REFERENCES [dbo].[ArticleRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionArticle'
CREATE INDEX [IX_FK_RegionArticle]
ON [dbo].[RegionRecordSet]
    ([Article_Id]);
GO

-- Creating foreign key on [Article_Id] in table 'ExcursionRecordSet'
ALTER TABLE [dbo].[ExcursionRecordSet]
ADD CONSTRAINT [FK_ExcursionArticle]
    FOREIGN KEY ([Article_Id])
    REFERENCES [dbo].[ArticleRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionArticle'
CREATE INDEX [IX_FK_ExcursionArticle]
ON [dbo].[ExcursionRecordSet]
    ([Article_Id]);
GO

-- Creating foreign key on [Excursion_Id] in table 'SightRecordSet'
ALTER TABLE [dbo].[SightRecordSet]
ADD CONSTRAINT [FK_ExcursionSight]
    FOREIGN KEY ([Excursion_Id])
    REFERENCES [dbo].[ExcursionRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionSight'
CREATE INDEX [IX_FK_ExcursionSight]
ON [dbo].[SightRecordSet]
    ([Excursion_Id]);
GO

-- Creating foreign key on [Excursion_Id] in table 'ReviewRecordSet'
ALTER TABLE [dbo].[ReviewRecordSet]
ADD CONSTRAINT [FK_ExcursionReview]
    FOREIGN KEY ([Excursion_Id])
    REFERENCES [dbo].[ExcursionRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionReview'
CREATE INDEX [IX_FK_ExcursionReview]
ON [dbo].[ReviewRecordSet]
    ([Excursion_Id]);
GO

-- Creating foreign key on [Sight_Id] in table 'ReviewRecordSet'
ALTER TABLE [dbo].[ReviewRecordSet]
ADD CONSTRAINT [FK_SightReview]
    FOREIGN KEY ([Sight_Id])
    REFERENCES [dbo].[SightRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SightReview'
CREATE INDEX [IX_FK_SightReview]
ON [dbo].[ReviewRecordSet]
    ([Sight_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------