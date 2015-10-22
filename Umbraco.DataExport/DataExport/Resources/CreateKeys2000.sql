ALTER TABLE [dbo].[cmsContent] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsContent] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsContentType] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsContentType] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsContentTypeAllowedContentType] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsContentTypeAllowedContentType] PRIMARY KEY  CLUSTERED 
	(
		[Id],
		[AllowedId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsContentVersion] WITH NOCHECK ADD 
	CONSTRAINT [DF_cmsContentVersion_VersionDate] DEFAULT (getdate()) FOR [VersionDate]
GO

ALTER TABLE [dbo].[cmsContentXml] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsContentXml] PRIMARY KEY  CLUSTERED 
	(
		[nodeId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsDataType] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsDataType] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsDataTypePreValues] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsDataTypePreValues] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsDictionary] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsDictionary] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsDocument] WITH NOCHECK ADD 
	CONSTRAINT [DF_cmsDocument_updateDate] DEFAULT (getdate()) FOR [updateDate],
	CONSTRAINT [DF_cmsDocument_newest] DEFAULT (0) FOR [newest],
	CONSTRAINT [PK_cmsDocument] PRIMARY KEY  CLUSTERED 
	(
		[versionId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsDocumentType] WITH NOCHECK ADD 
	CONSTRAINT [DF_cmsDocumentType_IsDefault] DEFAULT (0) FOR [IsDefault],
	CONSTRAINT [PK_cmsDocumentType] PRIMARY KEY  CLUSTERED 
	(
		[contentTypeNodeId],
		[templateNodeId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsLanguageText] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsLanguageText] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsMacro] WITH NOCHECK ADD 
	CONSTRAINT [DF_macro_macroUseInEditor] DEFAULT (0) FOR [macroUseInEditor],
	CONSTRAINT [DF_macro_macroRefreshRate] DEFAULT (0) FOR [macroRefreshRate],
	CONSTRAINT [DF_cmsMacro_macroCacheByPage] DEFAULT (1) FOR [macroCacheByPage],
	CONSTRAINT [DF_cmsMacro_macroCachePersonalized] DEFAULT (0) FOR [macroCachePersonalized],
	CONSTRAINT [DF_cmsMacro_macroDontRender] DEFAULT (0) FOR [macroDontRender],
	CONSTRAINT [PK_macro] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsMacroProperty] WITH NOCHECK ADD 
	CONSTRAINT [DF_macroProperty_macroPropertyHidden] DEFAULT (0) FOR [macroPropertyHidden],
	CONSTRAINT [DF_macroProperty_macroPropertySortOrder] DEFAULT (0) FOR [macroPropertySortOrder],
	CONSTRAINT [PK_macroProperty] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsMacroPropertyType] WITH NOCHECK ADD 
	CONSTRAINT [PK_macroPropertyType] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsMember] WITH NOCHECK ADD 
	CONSTRAINT [DF_cmsMember_Email] DEFAULT ('') FOR [Email],
	CONSTRAINT [DF_cmsMember_LoginName] DEFAULT ('') FOR [LoginName],
	CONSTRAINT [DF_cmsMember_Password] DEFAULT ('') FOR [Password]
GO

ALTER TABLE [dbo].[cmsMember2MemberGroup] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsMember2MemberGroup] PRIMARY KEY  CLUSTERED 
	(
		[Member],
		[MemberGroup]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsMemberType] WITH NOCHECK ADD 
	CONSTRAINT [DF_cmsMemberType_memberCanEdit] DEFAULT (0) FOR [memberCanEdit],
	CONSTRAINT [DF_cmsMemberType_viewOnProfile] DEFAULT (0) FOR [viewOnProfile],
	CONSTRAINT [PK_cmsMemberType] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsPropertyData] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsPropertyData] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsPropertyType] WITH NOCHECK ADD 
	CONSTRAINT [DF__cmsProper__sortO__1EA48E88] DEFAULT (0) FOR [sortOrder],
	CONSTRAINT [DF__cmsProper__manda__2180FB33] DEFAULT (0) FOR [mandatory],
	CONSTRAINT [PK_cmsPropertyType] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsTab] WITH NOCHECK ADD 
	CONSTRAINT [PK_cmsTab] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsTemplate] WITH NOCHECK ADD 
	CONSTRAINT [PK_templates] PRIMARY KEY  CLUSTERED 
	(
		[pk]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoApp] WITH NOCHECK ADD 
	CONSTRAINT [DF_app_sortOrder] DEFAULT (0) FOR [sortOrder],
	CONSTRAINT [PK_umbracoApp] PRIMARY KEY  CLUSTERED 
	(
		[appAlias]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoAppTree] WITH NOCHECK ADD 
	CONSTRAINT [DF_umbracoAppTree_treeSilent] DEFAULT (0) FOR [treeSilent],
	CONSTRAINT [DF_umbracoAppTree_treeInitialize] DEFAULT (1) FOR [treeInitialize],
	CONSTRAINT [PK_umbracoAppTree] PRIMARY KEY  CLUSTERED 
	(
		[appAlias],
		[treeAlias]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoDomains] WITH NOCHECK ADD 
	CONSTRAINT [PK_domains] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoLanguage] WITH NOCHECK ADD 
	CONSTRAINT [PK_language] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoLog] WITH NOCHECK ADD 
	CONSTRAINT [DF_umbracoLog_Datestamp] DEFAULT (getdate()) FOR [Datestamp],
	CONSTRAINT [PK_umbracoLog] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoNode] WITH NOCHECK ADD 
	CONSTRAINT [DF_umbracoNode_trashed] DEFAULT (0) FOR [trashed],
	CONSTRAINT [DF_umbracoNode_createDate] DEFAULT (getdate()) FOR [createDate],
	CONSTRAINT [PK_structure] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoRelation] WITH NOCHECK ADD 
	CONSTRAINT [DF_umbracoRelation_datetime] DEFAULT (getdate()) FOR [datetime],
	CONSTRAINT [PK_umbracoRelation] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoRelationType] WITH NOCHECK ADD 
	CONSTRAINT [PK_umbracoRelationType] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoStatEntry] WITH NOCHECK ADD 
	CONSTRAINT [PK_umbracoStatEntry] PRIMARY KEY  CLUSTERED 
	(
		[SessionId],
		[EntryTime],
		[RefNodeId],
		[NodeId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoStatSession] WITH NOCHECK ADD 
	CONSTRAINT [DF__umbracoSt__allow__22751F6C] DEFAULT (0) FOR [allowCookies],
	CONSTRAINT [DF__umbracoSt__isHum__7C4F7684] DEFAULT (0) FOR [isHuman],
	CONSTRAINT [PK_umbracoStartSession] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoStylesheet] WITH NOCHECK ADD 
	CONSTRAINT [PK_umbracoStylesheet] PRIMARY KEY  CLUSTERED 
	(
		[nodeId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoStylesheetProperty] WITH NOCHECK ADD 
	CONSTRAINT [DF_stylesheetProperty_stylesheetPropertyEditor] DEFAULT (0) FOR [stylesheetPropertyEditor],
	CONSTRAINT [PK_stylesheetProperty] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUser] WITH NOCHECK ADD 
	CONSTRAINT [DF_umbracoUser_userDisabled] DEFAULT (0) FOR [userDisabled],
	CONSTRAINT [DF_umbracoUser_userNoConsole] DEFAULT (0) FOR [userNoConsole],
	CONSTRAINT [PK_user] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUser2NodeNotify] WITH NOCHECK ADD 
	CONSTRAINT [PK_umbracoUser2NodeNotify] PRIMARY KEY  CLUSTERED 
	(
		[userId],
		[nodeId],
		[action]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUser2NodePermission] WITH NOCHECK ADD 
	CONSTRAINT [PK_umbracoUser2NodePermission] PRIMARY KEY  CLUSTERED 
	(
		[userId],
		[nodeId],
		[permission]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUser2app] WITH NOCHECK ADD 
	CONSTRAINT [PK_user2app] PRIMARY KEY  CLUSTERED 
	(
		[user],
		[app]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUser2userGroup] WITH NOCHECK ADD 
	CONSTRAINT [PK_user2userGroup] PRIMARY KEY  CLUSTERED 
	(
		[user],
		[userGroup]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUserGroup] WITH NOCHECK ADD 
	CONSTRAINT [PK_userGroup] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[umbracoUserType] WITH NOCHECK ADD 
	CONSTRAINT [PK_userType] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[cmsContent] WITH NOCHECK ADD 
	CONSTRAINT [FK_cmsContent_umbracoNode] FOREIGN KEY 
	(
		[nodeId]
	) REFERENCES [dbo].[umbracoNode] (
		[id]
	)
GO

ALTER TABLE [dbo].[cmsContentType] WITH NOCHECK ADD 
	CONSTRAINT [FK_cmsContentType_umbracoNode] FOREIGN KEY 
	(
		[nodeId]
	) REFERENCES [dbo].[umbracoNode] (
		[id]
	)
GO

ALTER TABLE [dbo].[cmsDocument] WITH NOCHECK ADD 
	CONSTRAINT [FK_cmsDocument_umbracoNode] FOREIGN KEY 
	(
		[nodeId]
	) REFERENCES [dbo].[umbracoNode] (
		[id]
	)
GO

ALTER TABLE [dbo].[cmsMacroProperty] WITH NOCHECK ADD 
	CONSTRAINT [FK_umbracoMacroProperty_umbracoMacroPropertyType] FOREIGN KEY 
	(
		[macroPropertyType]
	) REFERENCES [dbo].[cmsMacroPropertyType] (
		[id]
	)
GO

ALTER TABLE [dbo].[cmsPropertyData] WITH NOCHECK ADD 
	CONSTRAINT [FK_cmsPropertyData_umbracoNode] FOREIGN KEY 
	(
		[contentNodeId]
	) REFERENCES [dbo].[umbracoNode] (
		[id]
	)
GO

ALTER TABLE [dbo].[cmsPropertyType] WITH NOCHECK ADD 
	CONSTRAINT [FK_cmsPropertyType_cmsTab] FOREIGN KEY 
	(
		[tabId]
	) REFERENCES [dbo].[cmsTab] (
		[id]
	)
GO

ALTER TABLE [dbo].[cmsTemplate] WITH NOCHECK ADD 
	CONSTRAINT [FK_cmsTemplate_umbracoNode] FOREIGN KEY 
	(
		[nodeId]
	) REFERENCES [dbo].[umbracoNode] (
		[id]
	)
GO

ALTER TABLE [dbo].[umbracoAppTree] WITH NOCHECK ADD 
	CONSTRAINT [FK_umbracoAppTree_umbracoApp] FOREIGN KEY 
	(
		[appAlias]
	) REFERENCES [dbo].[umbracoApp] (
		[appAlias]
	)
GO

ALTER TABLE [dbo].[umbracoNode] WITH NOCHECK ADD 
	CONSTRAINT [FK_umbracoNode_umbracoNode] FOREIGN KEY 
	(
		[parentID]
	) REFERENCES [dbo].[umbracoNode] (
		[id]
	)
GO

ALTER TABLE [dbo].[umbracoUser] WITH NOCHECK ADD 
	CONSTRAINT [FK_user_userType] FOREIGN KEY 
	(
		[userType]
	) REFERENCES [dbo].[umbracoUserType] (
		[id]
	)
GO

ALTER TABLE [dbo].[umbracoUser2app] WITH NOCHECK ADD 
	CONSTRAINT [FK_umbracoUser2app_umbracoApp] FOREIGN KEY 
	(
		[app]
	) REFERENCES [dbo].[umbracoApp] (
		[appAlias]
	),
	CONSTRAINT [FK_umbracoUser2app_umbracoUser] FOREIGN KEY 
	(
		[user]
	) REFERENCES [dbo].[umbracoUser] (
		[id]
	)
GO

ALTER TABLE [dbo].[umbracoUser2userGroup] WITH NOCHECK ADD 
	CONSTRAINT [FK_user2userGroup_user] FOREIGN KEY 
	(
		[user]
	) REFERENCES [dbo].[umbracoUser] (
		[id]
	),
	CONSTRAINT [FK_user2userGroup_userGroup] FOREIGN KEY 
	(
		[userGroup]
	) REFERENCES [dbo].[umbracoUserGroup] (
		[id]
	)
GO