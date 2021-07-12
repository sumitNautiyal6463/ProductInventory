USE [Inventory]
GO
/****** Object:  Table [dbo].[ProductItem]    Script Date: 12-07-2021 10:50:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductItem](
	[ItemId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Price] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[TotalPrice] [decimal](18, 2) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_ProductItem] PRIMARY KEY CLUSTERED 
(
	[ItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12-07-2021 10:50:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[Status] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_Name]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_Description]  DEFAULT (NULL) FOR [Description]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_Price]  DEFAULT ((0.00)) FOR [Price]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_TotalPrice]  DEFAULT ((0.00)) FOR [TotalPrice]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[ProductItem] ADD  CONSTRAINT [DF_ProductItem_UpdatedBy]  DEFAULT ((0)) FOR [UpdatedBy]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Name]  DEFAULT (NULL) FOR [Name]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_EmailId]  DEFAULT (NULL) FOR [EmailId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_UpdatedBy]  DEFAULT ((0)) FOR [UpdatedBy]
GO
