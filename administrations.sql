USE [HR]
GO

/****** Object:  Table [db_owner].[Administrations]    Script Date: 03/28/2013 15:42:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [db_owner].[Administrations](
	[AdministrationID] [int] NOT NULL,
	[AdministrationName] [nvarchar](100) NULL,
	[AdministrationHeadID] [int] NULL
) ON [PRIMARY]

GO

