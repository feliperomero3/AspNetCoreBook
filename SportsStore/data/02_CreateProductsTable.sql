USE [SportsStore]
GO

CREATE TABLE [dbo].[Products] (
	[ProductId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[Category] [varchar](50) NOT NULL,
	CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([ProductId] ASC)
)
GO
