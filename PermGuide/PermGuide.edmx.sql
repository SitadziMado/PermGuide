
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/23/2018 13:38:57
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
    ALTER TABLE [dbo].[ContentRecordSet_SightRecord] DROP CONSTRAINT [FK_RegionSight];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTimetable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TimetableRecordSet] DROP CONSTRAINT [FK_UserTimetable];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileRecordSet] DROP CONSTRAINT [FK_ArticleFile];
GO
IF OBJECT_ID(N'[dbo].[FK_SightArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentRecordSet_SightRecord] DROP CONSTRAINT [FK_SightArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_RegionArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RegionRecordSet] DROP CONSTRAINT [FK_RegionArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionArticle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentRecordSet_ExcursionRecord] DROP CONSTRAINT [FK_ExcursionArticle];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionSight_Excursion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExcursionSight] DROP CONSTRAINT [FK_ExcursionSight_Excursion];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionSight_Sight]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExcursionSight] DROP CONSTRAINT [FK_ExcursionSight_Sight];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRecordFileRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileRecordSet] DROP CONSTRAINT [FK_UserRecordFileRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ContentRecordReviewRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReviewRecordSet] DROP CONSTRAINT [FK_ContentRecordReviewRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRecordContentRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentRecordSet] DROP CONSTRAINT [FK_UserRecordContentRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_SightRecord_inherits_ContentRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentRecordSet_SightRecord] DROP CONSTRAINT [FK_SightRecord_inherits_ContentRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ArticleRecord_inherits_ContentRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentRecordSet_ArticleRecord] DROP CONSTRAINT [FK_ArticleRecord_inherits_ContentRecord];
GO
IF OBJECT_ID(N'[dbo].[FK_ExcursionRecord_inherits_ContentRecord]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContentRecordSet_ExcursionRecord] DROP CONSTRAINT [FK_ExcursionRecord_inherits_ContentRecord];
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
IF OBJECT_ID(N'[dbo].[RegionRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RegionRecordSet];
GO
IF OBJECT_ID(N'[dbo].[TimetableRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TimetableRecordSet];
GO
IF OBJECT_ID(N'[dbo].[ContentRecordSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentRecordSet];
GO
IF OBJECT_ID(N'[dbo].[ContentRecordSet_SightRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentRecordSet_SightRecord];
GO
IF OBJECT_ID(N'[dbo].[ContentRecordSet_ArticleRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentRecordSet_ArticleRecord];
GO
IF OBJECT_ID(N'[dbo].[ContentRecordSet_ExcursionRecord]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContentRecordSet_ExcursionRecord];
GO
IF OBJECT_ID(N'[dbo].[ExcursionSight]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExcursionSight];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserRecordSet'
CREATE TABLE [dbo].[UserRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Nickname] nvarchar(max)  NOT NULL,
    [Status] int  NOT NULL,
    [BanStatus_IsBanned] bit  NOT NULL,
    [BanStatus_BannedTill] datetime  NOT NULL
);
GO

-- Creating table 'ReviewRecordSet'
CREATE TABLE [dbo].[ReviewRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Mark] nvarchar(max)  NOT NULL,
    [UserRecord_Id] int  NOT NULL,
    [ContentRecord_Id] int  NOT NULL
);
GO

-- Creating table 'FileRecordSet'
CREATE TABLE [dbo].[FileRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Uri] nvarchar(max)  NOT NULL,
    [MediaType] int  NOT NULL,
    [ArticleRecord_Id] int  NOT NULL,
    [UserRecord_Id] int  NOT NULL
);
GO

-- Creating table 'RegionRecordSet'
CREATE TABLE [dbo].[RegionRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ArticleRecord_Id] int  NOT NULL
);
GO

-- Creating table 'TimetableRecordSet'
CREATE TABLE [dbo].[TimetableRecordSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Activities] nvarchar(max)  NOT NULL,
    [UserRecord_Id] int  NOT NULL
);
GO

-- Creating table 'ContentRecordSet'
CREATE TABLE [dbo].[ContentRecordSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ProposalStatus] int  NOT NULL,
    [UserRecord_Id] int  NOT NULL
);
GO

-- Creating table 'ContentRecordSet_SightRecord'
CREATE TABLE [dbo].[ContentRecordSet_SightRecord] (
    [Location] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL,
    [RegionRecord_Id] int  NULL
);
GO

-- Creating table 'ContentRecordSet_ArticleRecord'
CREATE TABLE [dbo].[ContentRecordSet_ArticleRecord] (
    [Id] int  NOT NULL,
    [SightRecord_Id] int  NOT NULL
);
GO

-- Creating table 'ContentRecordSet_ExcursionRecord'
CREATE TABLE [dbo].[ContentRecordSet_ExcursionRecord] (
    [Id] int  NOT NULL,
    [ArticleRecord_Id] int  NOT NULL
);
GO

-- Creating table 'ExcursionSight'
CREATE TABLE [dbo].[ExcursionSight] (
    [ExcursionRecord_Id] int  NOT NULL,
    [SightRecord_Id] int  NOT NULL
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

-- Creating primary key on [Id] in table 'ContentRecordSet'
ALTER TABLE [dbo].[ContentRecordSet]
ADD CONSTRAINT [PK_ContentRecordSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentRecordSet_SightRecord'
ALTER TABLE [dbo].[ContentRecordSet_SightRecord]
ADD CONSTRAINT [PK_ContentRecordSet_SightRecord]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentRecordSet_ArticleRecord'
ALTER TABLE [dbo].[ContentRecordSet_ArticleRecord]
ADD CONSTRAINT [PK_ContentRecordSet_ArticleRecord]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ContentRecordSet_ExcursionRecord'
ALTER TABLE [dbo].[ContentRecordSet_ExcursionRecord]
ADD CONSTRAINT [PK_ContentRecordSet_ExcursionRecord]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ExcursionRecord_Id], [SightRecord_Id] in table 'ExcursionSight'
ALTER TABLE [dbo].[ExcursionSight]
ADD CONSTRAINT [PK_ExcursionSight]
    PRIMARY KEY CLUSTERED ([ExcursionRecord_Id], [SightRecord_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserRecord_Id] in table 'ReviewRecordSet'
ALTER TABLE [dbo].[ReviewRecordSet]
ADD CONSTRAINT [FK_UserReview]
    FOREIGN KEY ([UserRecord_Id])
    REFERENCES [dbo].[UserRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserReview'
CREATE INDEX [IX_FK_UserReview]
ON [dbo].[ReviewRecordSet]
    ([UserRecord_Id]);
GO

-- Creating foreign key on [RegionRecord_Id] in table 'ContentRecordSet_SightRecord'
ALTER TABLE [dbo].[ContentRecordSet_SightRecord]
ADD CONSTRAINT [FK_RegionSight]
    FOREIGN KEY ([RegionRecord_Id])
    REFERENCES [dbo].[RegionRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionSight'
CREATE INDEX [IX_FK_RegionSight]
ON [dbo].[ContentRecordSet_SightRecord]
    ([RegionRecord_Id]);
GO

-- Creating foreign key on [UserRecord_Id] in table 'TimetableRecordSet'
ALTER TABLE [dbo].[TimetableRecordSet]
ADD CONSTRAINT [FK_UserTimetable]
    FOREIGN KEY ([UserRecord_Id])
    REFERENCES [dbo].[UserRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTimetable'
CREATE INDEX [IX_FK_UserTimetable]
ON [dbo].[TimetableRecordSet]
    ([UserRecord_Id]);
GO

-- Creating foreign key on [ArticleRecord_Id] in table 'FileRecordSet'
ALTER TABLE [dbo].[FileRecordSet]
ADD CONSTRAINT [FK_ArticleFile]
    FOREIGN KEY ([ArticleRecord_Id])
    REFERENCES [dbo].[ContentRecordSet_ArticleRecord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticleFile'
CREATE INDEX [IX_FK_ArticleFile]
ON [dbo].[FileRecordSet]
    ([ArticleRecord_Id]);
GO

-- Creating foreign key on [SightRecord_Id] in table 'ContentRecordSet_ArticleRecord'
ALTER TABLE [dbo].[ContentRecordSet_ArticleRecord]
ADD CONSTRAINT [FK_SightArticle]
    FOREIGN KEY ([SightRecord_Id])
    REFERENCES [dbo].[ContentRecordSet_SightRecord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SightArticle'
CREATE INDEX [IX_FK_SightArticle]
ON [dbo].[ContentRecordSet_ArticleRecord]
    ([SightRecord_Id]);
GO

-- Creating foreign key on [ArticleRecord_Id] in table 'RegionRecordSet'
ALTER TABLE [dbo].[RegionRecordSet]
ADD CONSTRAINT [FK_RegionArticle]
    FOREIGN KEY ([ArticleRecord_Id])
    REFERENCES [dbo].[ContentRecordSet_ArticleRecord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RegionArticle'
CREATE INDEX [IX_FK_RegionArticle]
ON [dbo].[RegionRecordSet]
    ([ArticleRecord_Id]);
GO

-- Creating foreign key on [ArticleRecord_Id] in table 'ContentRecordSet_ExcursionRecord'
ALTER TABLE [dbo].[ContentRecordSet_ExcursionRecord]
ADD CONSTRAINT [FK_ExcursionArticle]
    FOREIGN KEY ([ArticleRecord_Id])
    REFERENCES [dbo].[ContentRecordSet_ArticleRecord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionArticle'
CREATE INDEX [IX_FK_ExcursionArticle]
ON [dbo].[ContentRecordSet_ExcursionRecord]
    ([ArticleRecord_Id]);
GO

-- Creating foreign key on [ExcursionRecord_Id] in table 'ExcursionSight'
ALTER TABLE [dbo].[ExcursionSight]
ADD CONSTRAINT [FK_ExcursionSight_Excursion]
    FOREIGN KEY ([ExcursionRecord_Id])
    REFERENCES [dbo].[ContentRecordSet_ExcursionRecord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SightRecord_Id] in table 'ExcursionSight'
ALTER TABLE [dbo].[ExcursionSight]
ADD CONSTRAINT [FK_ExcursionSight_Sight]
    FOREIGN KEY ([SightRecord_Id])
    REFERENCES [dbo].[ContentRecordSet_SightRecord]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExcursionSight_Sight'
CREATE INDEX [IX_FK_ExcursionSight_Sight]
ON [dbo].[ExcursionSight]
    ([SightRecord_Id]);
GO

-- Creating foreign key on [UserRecord_Id] in table 'FileRecordSet'
ALTER TABLE [dbo].[FileRecordSet]
ADD CONSTRAINT [FK_UserRecordFileRecord]
    FOREIGN KEY ([UserRecord_Id])
    REFERENCES [dbo].[UserRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecordFileRecord'
CREATE INDEX [IX_FK_UserRecordFileRecord]
ON [dbo].[FileRecordSet]
    ([UserRecord_Id]);
GO

-- Creating foreign key on [ContentRecord_Id] in table 'ReviewRecordSet'
ALTER TABLE [dbo].[ReviewRecordSet]
ADD CONSTRAINT [FK_ContentRecordReviewRecord]
    FOREIGN KEY ([ContentRecord_Id])
    REFERENCES [dbo].[ContentRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContentRecordReviewRecord'
CREATE INDEX [IX_FK_ContentRecordReviewRecord]
ON [dbo].[ReviewRecordSet]
    ([ContentRecord_Id]);
GO

-- Creating foreign key on [UserRecord_Id] in table 'ContentRecordSet'
ALTER TABLE [dbo].[ContentRecordSet]
ADD CONSTRAINT [FK_UserRecordContentRecord]
    FOREIGN KEY ([UserRecord_Id])
    REFERENCES [dbo].[UserRecordSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRecordContentRecord'
CREATE INDEX [IX_FK_UserRecordContentRecord]
ON [dbo].[ContentRecordSet]
    ([UserRecord_Id]);
GO

-- Creating foreign key on [Id] in table 'ContentRecordSet_SightRecord'
ALTER TABLE [dbo].[ContentRecordSet_SightRecord]
ADD CONSTRAINT [FK_SightRecord_inherits_ContentRecord]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ContentRecordSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ContentRecordSet_ArticleRecord'
ALTER TABLE [dbo].[ContentRecordSet_ArticleRecord]
ADD CONSTRAINT [FK_ArticleRecord_inherits_ContentRecord]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ContentRecordSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'ContentRecordSet_ExcursionRecord'
ALTER TABLE [dbo].[ContentRecordSet_ExcursionRecord]
ADD CONSTRAINT [FK_ExcursionRecord_inherits_ContentRecord]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[ContentRecordSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------