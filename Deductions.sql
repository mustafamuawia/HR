USE [HR]
GO

/****** Object:  Table [db_owner].[Deductions]    Script Date: 04/22/2013 16:41:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [db_owner].[Deductions](
	[رقم_الموظف] [int] NOT NULL,
	[اسم_الموظف] [nvarchar](250) NULL,
	[الجملة] [money] NULL,
	[التأمين_الاجتماعي] [money] NULL,
 CONSTRAINT [PK_Deductions] PRIMARY KEY CLUSTERED 
(
	[رقم_الموظف] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [db_owner].[Deductions]  WITH CHECK ADD  CONSTRAINT [FK_Deductions_Employees] FOREIGN KEY([رقم_الموظف])
REFERENCES [db_owner].[Employees] ([EmpID])
GO

ALTER TABLE [db_owner].[Deductions] CHECK CONSTRAINT [FK_Deductions_Employees]
GO

