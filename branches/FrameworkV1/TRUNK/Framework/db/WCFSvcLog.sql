/****** Object:  Table [dbo].[WCFSvcLog]    Script Date: 04/05/2012 12:03:05 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WCFSvcLog]') AND type in (N'U'))
DROP TABLE [dbo].[WCFSvcLog]
GO

USE [Pfizer_WIN_Rewards]
GO

/****** Object:  Table [dbo].[WCFSvcLog]    Script Date: 04/05/2012 12:03:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[WCFSvcLog](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[operationName] [varchar](255) NULL,
	[callingAddress] [varchar](500) NULL,
	[requestMsgBody] [varchar](max) NULL,
	[responseMsgBody] [varchar](max) NULL,
	[dateCreated] [datetime] NULL,
 CONSTRAINT [PK_WCFSvcLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


