USE [HR]
GO

/****** Object:  Table [db_owner].[Allowances]    Script Date: 04/22/2013 16:42:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [db_owner].[Allowances](
	[رقم_الموظف] [int] NOT NULL,
	[اسم_الموظف] [nvarchar](250) NULL,
	[الجملة] [money] NULL,
	[المرتب_الأساسي] [money] NULL,
	[غلاء_المعيشة] [money] NULL,
	[بدل_سكن] [money] NULL,
	[بدل_الترحيل] [money] NULL,
	[حافز_نصف_شهري] [money] NULL,
 CONSTRAINT [PK_Allowances_1] PRIMARY KEY CLUSTERED 
(
	[رقم_الموظف] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [db_owner].[Allowances]  WITH CHECK ADD  CONSTRAINT [FK_Allowances_Employees] FOREIGN KEY([رقم_الموظف])
REFERENCES [db_owner].[Employees] ([EmpID])
GO

ALTER TABLE [db_owner].[Allowances] CHECK CONSTRAINT [FK_Allowances_Employees]
GO

