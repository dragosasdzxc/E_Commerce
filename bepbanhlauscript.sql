USE [master]
GO
/****** Object:  Database [bepbanhlau]    Script Date: 8/18/2021 9:42:58 PM ******/
CREATE DATABASE [bepbanhlau]
GO
USE [bepbanhlau]
GO
/****** Object:  Table [dbo].[bill]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill](
	[id_bill] [nvarchar](100) NOT NULL,
	[user_id] [nvarchar](100) NOT NULL,
	[status_id] [nvarchar](100) NULL,
	[total] [int] NULL,
	[description] [nvarchar](200) NULL,
 CONSTRAINT [PK_bill] PRIMARY KEY CLUSTERED 
(
	[id_bill] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bill_detail]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bill_detail](
	[id_bill_detail] [int] IDENTITY(1,1) NOT NULL,
	[bill_id] [nvarchar](100) NOT NULL,
	[product_id] [nvarchar](100) NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_bill_detail] PRIMARY KEY CLUSTERED 
(
	[id_bill_detail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[branch]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[branch](
	[id_branch] [nvarchar](100) NOT NULL,
	[name_branch] [nvarchar](100) NOT NULL,
	[address] [nvarchar](100) NULL,
	[phone_number] [nvarchar](100) NULL,
	[description] [nvarchar](200) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_branch] PRIMARY KEY CLUSTERED 
(
	[id_branch] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cart]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cart](
	[id_cart] [nvarchar](100) NOT NULL,
	[product_id] [nvarchar](100) NULL,
	[user_id] [nvarchar](100) NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[id_cart] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[category]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id_category] [nvarchar](100) NOT NULL,
	[name_category] [nvarchar](100) NOT NULL,
	[description] [nvarchar](200) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[group]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[group](
	[id_group] [nvarchar](100) NOT NULL,
	[name_group] [nvarchar](100) NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_group] PRIMARY KEY CLUSTERED 
(
	[id_group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[news]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[news](
	[id_news] [nvarchar](100) NOT NULL,
	[user_id] [nvarchar](100) NULL,
	[header_name] [nvarchar](100) NULL,
	[contents] [nvarchar](max) NULL,
 CONSTRAINT [PK_news] PRIMARY KEY CLUSTERED 
(
	[id_news] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id_product] [nvarchar](100) NOT NULL,
	[name_product] [nvarchar](100) NOT NULL,
	[description] [nvarchar](max) NULL,
	[price] [int] NOT NULL,
	[sale] [int] NULL,
	[date_create] [bigint] NULL,
	[branch_id] [nvarchar](100) NULL,
	[status_id] [nvarchar](100) NULL,
	[active] [bit] NULL,
	[quantity] [int] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[role]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[role](
	[id_role] [nvarchar](100) NOT NULL,
	[name_role] [nvarchar](100) NOT NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id_role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[status]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[status](
	[id_status] [nvarchar](100) NOT NULL,
	[name_status] [nvarchar](100) NOT NULL,
	[active] [nvarchar](100) NULL,
	[group_id] [nvarchar](100) NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id_status] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sub_category]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sub_category](
	[id_sub_category] [nvarchar](100) NOT NULL,
	[name_sub_category] [nvarchar](100) NOT NULL,
	[category_id] [nvarchar](100) NOT NULL,
	[description] [nvarchar](100) NULL,
	[active] [bit] NULL,
 CONSTRAINT [PK_sub_category] PRIMARY KEY CLUSTERED 
(
	[id_sub_category] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 8/18/2021 9:42:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id_user] [nvarchar](100) NOT NULL,
	[full_name] [nvarchar](200) NOT NULL,
	[phone_number] [nvarchar](50) NOT NULL,
	[email] [nvarchar](100) NULL,
	[password] [nvarchar](max) NOT NULL,
	[city] [nvarchar](100) NULL,
	[district] [nvarchar](100) NULL,
	[ward] [nvarchar](100) NULL,
	[address] [nvarchar](200) NULL,
	[role_id] [nvarchar](100) NULL,
	[status_id] [nvarchar](100) NULL,
	[branch_id] [nvarchar](100) NULL,
	[activation_code] [nvarchar](max) NULL,
	[active] [bit] NULL CONSTRAINT [DF_user_active]  DEFAULT ((1)),
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[branch] ([id_branch], [name_branch], [address], [phone_number], [description], [active]) VALUES (N'br1', N'Branch1', N'b1', N'0123456789', N'b1', 1)
INSERT [dbo].[group] ([id_group], [name_group], [active]) VALUES (N'nw', N'News', 1)
INSERT [dbo].[group] ([id_group], [name_group], [active]) VALUES (N'pr', N'Product', 1)
INSERT [dbo].[group] ([id_group], [name_group], [active]) VALUES (N'us', N'User', 1)
INSERT [dbo].[role] ([id_role], [name_role], [active]) VALUES (N'ad', N'Admin', 1)
INSERT [dbo].[role] ([id_role], [name_role], [active]) VALUES (N'mgr', N'Manager', 1)
INSERT [dbo].[role] ([id_role], [name_role], [active]) VALUES (N'us', N'User', 1)
INSERT [dbo].[status] ([id_status], [name_status], [active], [group_id]) VALUES (N'av', N'Validated', N'1', N'us')
INSERT [dbo].[status] ([id_status], [name_status], [active], [group_id]) VALUES (N'noav', N'Not validate', N'1', N'us')
INSERT [dbo].[user] ([id_user], [full_name], [phone_number], [email], [password], [city], [district], [ward], [address], [role_id], [status_id], [branch_id], [activation_code], [active]) VALUES (N'637602997200123456789test', N'test', N'0123456789', N'test@email.com', N'Pr7209rryi28Oy78G719ZQ==', N'83', N'835', N'29089', N'test', N'ad', N'noav', N'br1', N'43a78c84264e47ac9751038b74d9c6bc', 1)
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF_product_price]  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[product] ADD  CONSTRAINT [DF_product_sale]  DEFAULT ((0)) FOR [sale]
GO
USE [master]
GO
ALTER DATABASE [bepbanhlau] SET  READ_WRITE 
GO
