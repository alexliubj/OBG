USE [master]
GO
/****** Object:  Database [OBG_]    Script Date: 05/27/2014 08:07:25 ******/
CREATE DATABASE [OBG_] ON  PRIMARY 
( NAME = N'OBG_', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\OBG_.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'OBG__log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\OBG__log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [OBG_] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OBG_].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OBG_] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [OBG_] SET ANSI_NULLS OFF
GO
ALTER DATABASE [OBG_] SET ANSI_PADDING OFF
GO
ALTER DATABASE [OBG_] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [OBG_] SET ARITHABORT OFF
GO
ALTER DATABASE [OBG_] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [OBG_] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [OBG_] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [OBG_] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [OBG_] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [OBG_] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [OBG_] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [OBG_] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [OBG_] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [OBG_] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [OBG_] SET  DISABLE_BROKER
GO
ALTER DATABASE [OBG_] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [OBG_] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [OBG_] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [OBG_] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [OBG_] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [OBG_] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [OBG_] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [OBG_] SET  READ_WRITE
GO
ALTER DATABASE [OBG_] SET RECOVERY SIMPLE
GO
ALTER DATABASE [OBG_] SET  MULTI_USER
GO
ALTER DATABASE [OBG_] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [OBG_] SET DB_CHAINING OFF
GO
USE [OBG_]
GO
/****** Object:  Table [dbo].[Wheels]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Wheels](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varchar](250) NOT NULL,
	[Style] [varchar](50) NOT NULL,
	[Brand] [varchar](50) NOT NULL,
	[Size] [varchar](50) NOT NULL,
	[PCD] [varchar](50) NOT NULL,
	[Finish] [varchar](50) NOT NULL,
	[Offset] [varchar](50) NOT NULL,
	[SEAT] [varchar](50) NOT NULL,
	[BORE] [varchar](50) NOT NULL,
	[Weight] [varchar](50) NOT NULL,
	[ONHand] [varchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PartNO] [varchar](255) NULL,
 CONSTRAINT [PK_Product2] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Wheels] ON
INSERT [dbo].[Wheels] ([ProductId], [Image], [Style], [Brand], [Size], [PCD], [Finish], [Offset], [SEAT], [BORE], [Weight], [ONHand], [Price], [CategoryId], [PartNO]) VALUES (3, N'Image', N'Style', N'Brand', N'Size', N'PCD', N'Finish', N'Offset', N'SEAT', N'BORE', N'Weight', N'ONHand', 1.2, 2, NULL)
SET IDENTITY_INSERT [dbo].[Wheels] OFF
/****** Object:  Table [dbo].[Users]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserPwd] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Email] [varchar](250) NOT NULL,
	[CompanyName] [varchar](250) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[BillingHouseNo] [varchar](250) NULL,
	[BillingPostCode] [varchar](50) NULL,
	[ShippingHouseNo] [varchar](250) NULL,
	[ShippingPostCode] [varchar](50) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[ShippingStreet] [varchar](25) NULL,
	[ShippingCity] [varchar](255) NULL,
	[ShippingPro] [varchar](255) NULL,
	[BillingStreet] [varchar](255) NULL,
	[BillingCity] [varchar](255) NULL,
	[BillingPro] [varchar](255) NULL,
	[IsSameAddress] [int] NULL,
	[RegionId] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (1, N'1234', N'123', 1, N'adf@email.com', N'neo', N'416-833-4368', NULL, NULL, N'lee center', N'm1h 3j2', N'bo', N'liu', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (2, N'????????', N'test', 0, N'test@test.com', N'test@test.com', N'4168334368', NULL, NULL, N'sdfs', N'M1H 3J2', N'test', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (3, N'????????', N'test1', 0, N'test@test.com', N'test@test.com', N'4168334368', NULL, NULL, N'sdfsfs', N'M1H 3J2', N'test', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (5, N'???????', N'test1', 0, N'test@test.com', N'test@test.com', N'4168334368', NULL, NULL, N'sdfsfs', N'M1H 3J2', N'test', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (6, N'????????', N'test2', 0, N'test@test.com', N'test@test.com', N'4168334368', NULL, NULL, N'2301-1 Lee Center Drive', N'M1H 3J2', N'test', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (7, N'3HhxGocas55cs8Bct+/O3Q==', N'test3', 0, N'test@test.com', N'test@test.com', N'4168334368', NULL, NULL, N'2301-1 Lee Center Drive', N'M1H 3J2', N'test', N'test', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingHouseNo], [BillingPostCode], [ShippingHouseNo], [ShippingPostCode], [FirstName], [LastName], [ShippingStreet], [ShippingCity], [ShippingPro], [BillingStreet], [BillingCity], [BillingPro], [IsSameAddress], [RegionId]) VALUES (8, N'WuOAhuLJ9R1M//y+fCzGHw==', N'test4', 0, N'testew@ssdc.com', N'testew@ssdc.com', N'4168334368', N'', N'', N'2301-1 Lee Center Drive', N'M1H 3J2', N'neo', N'sdfsdf', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[UserRole]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRole](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Des] [varchar](250) NULL,
 CONSTRAINT [PK_UserRole22] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON
INSERT [dbo].[UserRole] ([UID], [RoleId], [UserId], [Des]) VALUES (3, 0, 1, N'admin')
INSERT [dbo].[UserRole] ([UID], [RoleId], [UserId], [Des]) VALUES (4, 1, 2, N'customer')
INSERT [dbo].[UserRole] ([UID], [RoleId], [UserId], [Des]) VALUES (5, 1, 2, N'customer')
INSERT [dbo].[UserRole] ([UID], [RoleId], [UserId], [Des]) VALUES (6, 1, 6, N'customer')
INSERT [dbo].[UserRole] ([UID], [RoleId], [UserId], [Des]) VALUES (7, 1, 7, N'customer')
INSERT [dbo].[UserRole] ([UID], [RoleId], [UserId], [Des]) VALUES (8, 1, 8, N'des')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
/****** Object:  Table [dbo].[Tires]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tires](
	[tireId] [int] IDENTITY(1,1) NOT NULL,
	[partNo] [varchar](50) NOT NULL,
	[size] [varchar](50) NOT NULL,
	[pricing] [float] NOT NULL,
	[season] [varchar](50) NOT NULL,
	[categoryId] [varchar](50) NOT NULL,
	[brand] [varchar](255) NOT NULL,
	[image] [varchar](1023) NULL,
 CONSTRAINT [PK_Tire] PRIMARY KEY CLUSTERED 
(
	[tireId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShoppingCart](
	[UserId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Qty] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shipping]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shipping](
	[RegionId] [int] IDENTITY(1,1) NOT NULL,
	[RegionName] [varchar](50) NOT NULL,
	[RegionPrice] [float] NOT NULL,
	[DevMethods] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Shipping2] PRIMARY KEY CLUSTERED 
(
	[RegionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Shipping] ON
INSERT [dbo].[Shipping] ([RegionId], [RegionName], [RegionPrice], [DevMethods]) VALUES (1, N'North York', 3.5, N'ups')
INSERT [dbo].[Shipping] ([RegionId], [RegionName], [RegionPrice], [DevMethods]) VALUES (2, N'Scarborough', 2.5, N'ups')
SET IDENTITY_INSERT [dbo].[Shipping] OFF
/****** Object:  Table [dbo].[RoleModule]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModule](
	[UID] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
	[ModuleID] [int] NOT NULL,
 CONSTRAINT [PK_RoleModule] PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](255) NOT NULL,
	[Des] [varchar](255) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([RoleId], [RoleName], [Des]) VALUES (1, N'dtes', N'tes')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[ResetPwds]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ResetPwds](
	[uid] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](250) NOT NULL,
	[sectKey] [varchar](250) NOT NULL,
 CONSTRAINT [PK_ResetPwds] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[ResetPwds] ON
INSERT [dbo].[ResetPwds] ([uid], [email], [sectKey]) VALUES (1, N'email', N'dkfjslkjf')
INSERT [dbo].[ResetPwds] ([uid], [email], [sectKey]) VALUES (2, N'alexliubo@gmail.com', N'MDRLWLWO-JYJNFOBB')
INSERT [dbo].[ResetPwds] ([uid], [email], [sectKey]) VALUES (3, N'alexliubo@gmail.com', N'UEJLHUSR-GHAAJRXR')
INSERT [dbo].[ResetPwds] ([uid], [email], [sectKey]) VALUES (4, N'alexliubo@gmail.com', N'DNQKDVGJ-RBLHGORP')
INSERT [dbo].[ResetPwds] ([uid], [email], [sectKey]) VALUES (5, N'alexliubo@gmail.com', N'JGONDUBX-RNOATKZS')
SET IDENTITY_INSERT [dbo].[ResetPwds] OFF
/****** Object:  Table [dbo].[ProductPermission]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPermission](
	[productId] [int] NOT NULL,
	[roleId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLine](
	[ProductId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[DiscountRate] [float] NOT NULL,
	[OrderId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[OrderId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OrderDate] [date] NOT NULL,
	[Status] [int] NOT NULL,
	[PO] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON
INSERT [dbo].[Order] ([OrderId], [UserId], [OrderDate], [Status], [PO]) VALUES (1, 2, CAST(0x88380B00 AS Date), 2, N'ss')
INSERT [dbo].[Order] ([OrderId], [UserId], [OrderDate], [Status], [PO]) VALUES (2, 2, CAST(0x88380B00 AS Date), 2, N'ss')
SET IDENTITY_INSERT [dbo].[Order] OFF
/****** Object:  Table [dbo].[Inventory]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory](
	[ProductId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HomePage]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HomePage](
	[Image1] [varchar](255) NOT NULL,
	[Des1] [varchar](2048) NOT NULL,
	[Image2] [varchar](255) NOT NULL,
	[Des2] [varchar](255) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[UserId] [int] NOT NULL,
	[DisRate] [float] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Discount] ([UserId], [DisRate]) VALUES (1, 0.2)
INSERT [dbo].[Discount] ([UserId], [DisRate]) VALUES (2, 0.5)
/****** Object:  Table [dbo].[Category]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category_1] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'tire')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (5, N'access')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (6, N'newcategoty')
SET IDENTITY_INSERT [dbo].[Category] OFF
/****** Object:  Table [dbo].[Accessories]    Script Date: 05/27/2014 08:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Accessories](
	[partNo] [varchar](50) NOT NULL,
	[accId] [int] IDENTITY(1,1) NOT NULL,
	[image] [varchar](1023) NULL,
	[des] [varchar](250) NOT NULL,
	[pricing] [float] NOT NULL,
	[categoryId] [int] NOT NULL,
	[name] [varchar](255) NOT NULL,
	[brand] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Accessoriese] PRIMARY KEY CLUSTERED 
(
	[accId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Default [DF_Users_IsSameAddress]    Script Date: 05/27/2014 08:07:26 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsSameAddress]  DEFAULT ((1)) FOR [IsSameAddress]
GO
