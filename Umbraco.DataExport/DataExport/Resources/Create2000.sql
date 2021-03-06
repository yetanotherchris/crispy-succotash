if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_umbracoMacroProperty_umbracoMacroPropertyType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsMacroProperty] DROP CONSTRAINT FK_umbracoMacroProperty_umbracoMacroPropertyType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cmsPropertyType_cmsTab]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsPropertyType] DROP CONSTRAINT FK_cmsPropertyType_cmsTab
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_umbracoAppTree_umbracoApp]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoAppTree] DROP CONSTRAINT FK_umbracoAppTree_umbracoApp
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_umbracoUser2app_umbracoApp]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoUser2app] DROP CONSTRAINT FK_umbracoUser2app_umbracoApp
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cmsContent_umbracoNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsContent] DROP CONSTRAINT FK_cmsContent_umbracoNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cmsContentType_umbracoNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsContentType] DROP CONSTRAINT FK_cmsContentType_umbracoNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cmsDocument_umbracoNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsDocument] DROP CONSTRAINT FK_cmsDocument_umbracoNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cmsPropertyData_umbracoNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsPropertyData] DROP CONSTRAINT FK_cmsPropertyData_umbracoNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_cmsTemplate_umbracoNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[cmsTemplate] DROP CONSTRAINT FK_cmsTemplate_umbracoNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_umbracoNode_umbracoNode]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoNode] DROP CONSTRAINT FK_umbracoNode_umbracoNode
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_umbracoUser2app_umbracoUser]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoUser2app] DROP CONSTRAINT FK_umbracoUser2app_umbracoUser
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_user2userGroup_user]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoUser2userGroup] DROP CONSTRAINT FK_user2userGroup_user
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_user2userGroup_userGroup]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoUser2userGroup] DROP CONSTRAINT FK_user2userGroup_userGroup
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_user_userType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[umbracoUser] DROP CONSTRAINT FK_user_userType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsContent]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsContent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsContentType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsContentType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsContentTypeAllowedContentType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsContentTypeAllowedContentType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsContentVersion]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsContentVersion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsContentXml]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsContentXml]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsDataType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsDataType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsDataTypePreValues]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsDataTypePreValues]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsDictionary]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsDictionary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsDocument]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsDocument]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsDocumentType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsDocumentType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsLanguageText]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsLanguageText]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsMacro]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsMacro]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsMacroProperty]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsMacroProperty]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsMacroPropertyType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsMacroPropertyType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsMember]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsMember]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsMember2MemberGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsMember2MemberGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsMemberType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsMemberType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsPropertyData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsPropertyData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsPropertyType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsPropertyType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsStylesheet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsStylesheet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsStylesheetProperty]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsStylesheetProperty]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsTab]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsTab]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[cmsTemplate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[cmsTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoApp]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoApp]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoAppTree]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoAppTree]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoDomains]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoDomains]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoLanguage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoLanguage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoNode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoNode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoRelation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoRelation]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoRelationType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoRelationType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoStatEntry]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoStatEntry]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoStatSession]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoStatSession]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoStylesheet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoStylesheet]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoStylesheetProperty]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoStylesheetProperty]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUser]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUser2NodeNotify]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUser2NodeNotify]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUser2NodePermission]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUser2NodePermission]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUser2app]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUser2app]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUser2userGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUser2userGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUserGroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUserGroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUserLogins]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUserLogins]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[umbracoUserType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[umbracoUserType]
GO

CREATE TABLE [dbo].[cmsContent] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[nodeId] [int] NOT NULL ,
	[contentType] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsContentType] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[nodeId] [int] NOT NULL ,
	[alias] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[icon] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsContentTypeAllowedContentType] (
	[Id] [int] NOT NULL ,
	[AllowedId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsContentVersion] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[ContentId] [int] NOT NULL ,
	[VersionId] [uniqueidentifier] NOT NULL ,
	[VersionDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsContentXml] (
	[nodeId] [int] NOT NULL ,
	[xml] [ntext] COLLATE Danish_Norwegian_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsDataType] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[nodeId] [int] NOT NULL ,
	[controlId] [uniqueidentifier] NOT NULL ,
	[dbType] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsDataTypePreValues] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[datatypeNodeId] [int] NOT NULL ,
	[value] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sortorder] [int] NOT NULL ,
	[alias] [nvarchar] (50) COLLATE Danish_Norwegian_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsDictionary] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[id] [uniqueidentifier] NOT NULL ,
	[parent] [uniqueidentifier] NOT NULL ,
	[key] [nvarchar] (1000) COLLATE Danish_Norwegian_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsDocument] (
	[nodeId] [int] NOT NULL ,
	[published] [bit] NOT NULL ,
	[documentUser] [int] NOT NULL ,
	[versionId] [uniqueidentifier] NOT NULL ,
	[text] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[releaseDate] [datetime] NULL ,
	[expireDate] [datetime] NULL ,
	[updateDate] [datetime] NOT NULL ,
	[templateId] [int] NULL ,
	[alias] [nvarchar] (255) COLLATE Danish_Norwegian_CI_AS NULL ,
	[newest] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsDocumentType] (
	[contentTypeNodeId] [int] NOT NULL ,
	[templateNodeId] [int] NOT NULL ,
	[IsDefault] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsLanguageText] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[languageId] [int] NOT NULL ,
	[UniqueId] [uniqueidentifier] NOT NULL ,
	[value] [nvarchar] (1000) COLLATE Danish_Norwegian_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsMacro] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[macroUseInEditor] [bit] NOT NULL ,
	[macroRefreshRate] [int] NOT NULL ,
	[macroAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[macroName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroScriptType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroScriptAssembly] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroXSLT] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroCacheByPage] [bit] NOT NULL ,
	[macroCachePersonalized] [bit] NOT NULL ,
	[macroDontRender] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsMacroProperty] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[macroPropertyHidden] [bit] NOT NULL ,
	[macroPropertyType] [smallint] NOT NULL ,
	[macro] [int] NOT NULL ,
	[macroPropertySortOrder] [tinyint] NOT NULL ,
	[macroPropertyAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[macroPropertyName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsMacroPropertyType] (
	[id] [smallint] IDENTITY (1, 1) NOT NULL ,
	[macroPropertyTypeAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroPropertyTypeRenderAssembly] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroPropertyTypeRenderType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[macroPropertyTypeBaseType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsMember] (
	[nodeId] [int] NOT NULL ,
	[Email] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LoginName] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Password] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsMember2MemberGroup] (
	[Member] [int] NOT NULL ,
	[MemberGroup] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsMemberType] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[NodeId] [int] NOT NULL ,
	[propertytypeId] [int] NOT NULL ,
	[memberCanEdit] [bit] NOT NULL ,
	[viewOnProfile] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsPropertyData] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[contentNodeId] [int] NOT NULL ,
	[versionId] [uniqueidentifier] NULL ,
	[propertytypeid] [int] NOT NULL ,
	[dataInt] [int] NULL ,
	[dataDate] [datetime] NULL ,
	[dataNvarchar] [nvarchar] (500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[dataNtext] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsPropertyType] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[dataTypeId] [int] NOT NULL ,
	[contentTypeId] [int] NOT NULL ,
	[tabId] [int] NULL ,
	[Alias] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Name] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[helpText] [nvarchar] (1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[sortOrder] [int] NOT NULL ,
	[mandatory] [bit] NOT NULL ,
	[validationRegExp] [nvarchar] (255) COLLATE Danish_Norwegian_CI_AS NULL ,
	[Description] [nvarchar] (2000) COLLATE Danish_Norwegian_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsStylesheet] (
	[nodeId] [int] NOT NULL ,
	[filename] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[content] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsStylesheetProperty] (
	[nodeId] [int] NOT NULL ,
	[stylesheetPropertyEditor] [bit] NULL ,
	[stylesheetPropertyAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[stylesheetPropertyValue] [nvarchar] (400) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsTab] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[contenttypeNodeId] [int] NOT NULL ,
	[text] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[sortorder] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[cmsTemplate] (
	[pk] [int] IDENTITY (1, 1) NOT NULL ,
	[nodeId] [int] NOT NULL ,
	[master] [int] NULL ,
	[alias] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[design] [ntext] COLLATE Danish_Norwegian_CI_AS NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoApp] (
	[sortOrder] [tinyint] NOT NULL ,
	[appAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[appIcon] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[appName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[appInitWithTreeAlias] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoAppTree] (
	[treeSilent] [bit] NOT NULL ,
	[treeInitialize] [bit] NOT NULL ,
	[treeSortOrder] [tinyint] NOT NULL ,
	[appAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[treeAlias] [nvarchar] (150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[treeTitle] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[treeIconClosed] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[treeIconOpen] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[treeHandlerAssembly] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[treeHandlerType] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoDomains] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[domainDefaultLanguage] [int] NULL ,
	[domainRootStructureID] [int] NULL ,
	[domainName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoLanguage] (
	[id] [smallint] IDENTITY (1, 1) NOT NULL ,
	[languageISOCode] [nvarchar] (5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[languageCultureName] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoLog] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[userId] [int] NOT NULL ,
	[NodeId] [int] NOT NULL ,
	[Datestamp] [datetime] NOT NULL ,
	[logHeader] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[logComment] [nvarchar] (1000) COLLATE Danish_Norwegian_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoNode] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[trashed] [bit] NOT NULL ,
	[parentID] [int] NOT NULL ,
	[nodeUser] [int] NULL ,
	[level] [smallint] NOT NULL ,
	[path] [nvarchar] (150) COLLATE Danish_Norwegian_CI_AS NOT NULL ,
	[sortOrder] [int] NOT NULL ,
	[uniqueID] [uniqueidentifier] NULL ,
	[text] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[nodeObjectType] [uniqueidentifier] NULL ,
	[createDate] [datetime] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoRelation] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[parentId] [int] NOT NULL ,
	[childId] [int] NOT NULL ,
	[relType] [int] NOT NULL ,
	[datetime] [datetime] NOT NULL ,
	[comment] [nvarchar] (1000) COLLATE Danish_Norwegian_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoRelationType] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[dual] [bit] NOT NULL ,
	[parentObjectType] [uniqueidentifier] NOT NULL ,
	[childObjectType] [uniqueidentifier] NOT NULL ,
	[name] [nvarchar] (255) COLLATE Danish_Norwegian_CI_AS NOT NULL ,
	[alias] [nvarchar] (100) COLLATE Danish_Norwegian_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoStatEntry] (
	[SessionId] [int] NOT NULL ,
	[EntryTime] [datetime] NOT NULL ,
	[RefNodeId] [int] NOT NULL ,
	[NodeId] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoStatSession] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[MemberId] [uniqueidentifier] NULL ,
	[NewsletterId] [int] NULL ,
	[ReturningUser] [bit] NOT NULL ,
	[SessionStart] [datetime] NOT NULL ,
	[SessionEnd] [datetime] NULL ,
	[Language] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[UserAgent] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Browser] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[BrowserVersion] [nvarchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[OperatingSystem] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Ip] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Referrer] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[ReferrerKeyword] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[allowCookies] [bit] NOT NULL ,
	[visitorId] [char] (36) COLLATE Danish_Norwegian_CI_AS NULL ,
	[browserType] [nvarchar] (255) COLLATE Danish_Norwegian_CI_AS NULL ,
	[isHuman] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoStylesheet] (
	[nodeId] [int] NOT NULL ,
	[filename] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[content] [ntext] COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoStylesheetProperty] (
	[id] [smallint] IDENTITY (1, 1) NOT NULL ,
	[stylesheetPropertyEditor] [bit] NOT NULL ,
	[stylesheet] [tinyint] NOT NULL ,
	[stylesheetPropertyAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[stylesheetPropertyName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[stylesheetPropertyValue] [nvarchar] (400) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUser] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[userDisabled] [bit] NOT NULL ,
	[userNoConsole] [bit] NOT NULL ,
	[userType] [smallint] NOT NULL ,
	[startStructureID] [int] NOT NULL ,
	[startMediaID] [int] NULL ,
	[userName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[userLogin] [nvarchar] (125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[userPassword] [nvarchar] (125) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[userEmail] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[userDefaultPermissions] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[userLanguage] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUser2NodeNotify] (
	[userId] [int] NOT NULL ,
	[nodeId] [int] NOT NULL ,
	[action] [char] (1) COLLATE Danish_Norwegian_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUser2NodePermission] (
	[userId] [int] NOT NULL ,
	[nodeId] [int] NOT NULL ,
	[permission] [char] (1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUser2app] (
	[user] [int] NOT NULL ,
	[app] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUser2userGroup] (
	[user] [int] NOT NULL ,
	[userGroup] [smallint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUserGroup] (
	[id] [smallint] IDENTITY (1, 1) NOT NULL ,
	[userGroupName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUserLogins] (
	[contextID] [uniqueidentifier] NOT NULL ,
	[userID] [int] NOT NULL ,
	[timeout] [bigint] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[umbracoUserType] (
	[id] [smallint] IDENTITY (1, 1) NOT NULL ,
	[userTypeAlias] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[userTypeName] [nvarchar] (255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[userTypeDefaultPermissions] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO