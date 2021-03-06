USE [Project1]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 26/4/2018 11:47:47 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,5001) NOT NULL,
	[Sender] [varchar](20) NOT NULL,
	[Receiver] [varchar](20) NOT NULL,
	[Message] [varchar](200) NOT NULL,
	[MessageDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 26/4/2018 11:47:48 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[AdminStatus] [bit] NOT NULL,
	[SuperAdminStatus] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (5002, N'Michael             ', N'George              ', N'brbtrwbtrw wtbt', CAST(N'2018-04-03T18:35:00.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (15004, N'George              ', N'Michael             ', N'hihiuhi', CAST(N'2018-04-03T18:36:00.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (20005, N'Michael             ', N'George              ', N'imoojo', CAST(N'2018-04-03T18:39:00.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25006, N'George              ', N'Michael             ', N'fewofjewei', CAST(N'2018-04-03T19:05:00.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (45010, N'Michael             ', N'George              ', N'Hello!!', CAST(N'2018-04-18T01:21:05.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (50011, N'Michael             ', N'as                  ', N'Hello!!', CAST(N'2018-04-18T01:21:17.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (60013, N'Michael             ', N'George              ', N'How Are You', CAST(N'2018-04-18T01:31:33.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (75016, N'George              ', N'Michael             ', N'Hello Michael!! How do you do??', CAST(N'2018-04-18T01:43:25.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (5031007, N'Michael             ', N'Ziopeppe            ', N'Michael', CAST(N'2018-04-19T00:41:40.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (5036008, N'Michael             ', N'George              ', N'sooas', CAST(N'2018-04-19T01:56:11.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (5046010, N'Michael             ', N'George              ', N'd', CAST(N'2018-04-19T02:21:23.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (10032007, N'as                  ', N'Michael             ', N'i', CAST(N'2018-04-20T21:43:11.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (10037008, N'as                  ', N'Michael             ', N'i', CAST(N'2018-04-20T21:43:25.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (10042009, N'as                  ', N'Michael             ', N'ello!', CAST(N'2018-04-20T21:43:36.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (10047010, N'Michael             ', N'George              ', N'Hello!', CAST(N'2018-04-20T21:44:48.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (10052011, N'sa', N'as', N'iord', CAST(N'2018-04-20T22:00:40.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (10057012, N'sa', N'George', N's', CAST(N'2018-04-20T22:05:39.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (15053011, N'admin', N'George', N'dewfq3', CAST(N'2018-04-21T22:15:09.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (15058012, N'admin', N'as', N'oooooo', CAST(N'2018-04-21T22:15:29.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25055011, N'sa', N'zxx', N'as', CAST(N'2018-04-26T23:03:36.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25060012, N'sa', N'sad', N'sds', CAST(N'2018-04-26T23:03:40.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25065013, N'zxx', N'sa', N'ew', CAST(N'2018-04-26T23:04:04.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25070014, N'zxx', N'sa', N'dwefwf', CAST(N'2018-04-26T23:04:15.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25075015, N'zxx', N'sa', N'cerce', CAST(N'2018-04-26T23:04:31.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25080016, N'sad', N'sa', N'aaaa', CAST(N'2018-04-26T23:04:55.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25085017, N'sa', N'zxx', N'dwsdw', CAST(N'2018-04-26T23:32:48.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25090018, N'sa', N'zxx', N'ss', CAST(N'2018-04-26T23:46:21.000' AS DateTime))
INSERT [dbo].[Messages] ([MessageID], [Sender], [Receiver], [Message], [MessageDateTime]) VALUES (25095019, N'sa', N'zxx', N'Hello!!', CAST(N'2018-04-26T23:46:28.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (1, N'admin', N'aDml3$', 0, 1, 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (6018, N'as', N'as', 1, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5030, N'bab', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (6, N'Babis', N'as', 0, 0, 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5025, N'Datia', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (3017, N'dim', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (4, N'George', N'as', 0, 1, 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5027, N'ho', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (1010, N'Jim', N'as', 0, 0, 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5029, N'Kostas', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (3010, N'Michael', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (3, N'Michael2', N'as', 0, 0, 1)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (6017, N'nick', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5017, N'qw', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (3015, N'sa', N'as', 0, 1, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (3016, N'sad', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5028, N'Tasos', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (5022, N'Ziopeppe', N'as', 0, 0, 0)
INSERT [dbo].[Users] ([UserID], [Username], [Password], [AdminStatus], [SuperAdminStatus], [Status]) VALUES (6022, N'zxx', N'as', 0, 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_AdminStatus]  DEFAULT ((0)) FOR [AdminStatus]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_SuperAdminStatus]  DEFAULT ((0)) FOR [SuperAdminStatus]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF__Users__Status__4AB81AF0]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Messages]  WITH CHECK ADD  CONSTRAINT [FK_Messages_Messages] FOREIGN KEY([MessageID])
REFERENCES [dbo].[Messages] ([MessageID])
GO
ALTER TABLE [dbo].[Messages] CHECK CONSTRAINT [FK_Messages_Messages]
GO
