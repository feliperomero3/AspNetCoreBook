USE [SportsStore]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (1, N'Kayak', N'A boat for one person', CAST(275.00 AS Decimal(8, 2)), N'Water sports')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (2, N'Life Jacket', N'Protective and fashionable', CAST(48.95 AS Decimal(8, 2)), N'Water sports')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (3, N'Football Ball', N'FIFA-approved size and weight', CAST(19.50 AS Decimal(8, 2)), N'Football')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (5, N'Corner Flags', N'Give your pitch a professional touch', CAST(34.95 AS Decimal(8, 2)), N'Football')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (6, N'Stadium', N'Flat-packed 35,000-seat stadium', CAST(79500.00 AS Decimal(8, 2)), N'Football')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (7, N'Thinking Cap', N'Improve brain efficiency by 75%', CAST(16.00 AS Decimal(8, 2)), N'Chess')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (8, N'Unsteady Chair', N'Secretly give your opponent a disadvantage', CAST(29.95 AS Decimal(8, 2)), N'Chess')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (9, N'Human Chess Board', N'A fun game for the family', CAST(75.00 AS Decimal(8, 2)), N'Chess')
GO
INSERT [dbo].[Products] ([ProductId], [Name], [Description], [Price], [Category]) VALUES (10, N'Bling-Bling King', N'Gold-plated, diamond-studded King', CAST(1200.00 AS Decimal(8, 2)), N'Chess')
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
