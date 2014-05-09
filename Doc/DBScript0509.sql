USE [master]
GO
/****** Object:  Database [OBG_]    Script Date: 05/09/2014 07:59:26 ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 05/09/2014 07:59:27 ******/
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
	[BillingAddress] [varchar](250) NULL,
	[BillingPostCode] [varchar](50) NULL,
	[ShippingAddress] [varchar](250) NULL,
	[ShippingPostCode] [varchar](50) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([UserId], [UserPwd], [UserName], [Status], [Email], [CompanyName], [Phone], [BillingAddress], [BillingPostCode], [ShippingAddress], [ShippingPostCode], [FirstName], [LastName]) VALUES (1, N'1234', N'123', 1, N'adf@email.com', N'neo', N'416-833-4368', NULL, NULL, N'lee center', N'm1h 3j2', N'bo', N'liu')
SET IDENTITY_INSERT [dbo].[Users] OFF
/****** Object:  Table [dbo].[UserRole]    Script Date: 05/09/2014 07:59:27 ******/
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
SET IDENTITY_INSERT [dbo].[UserRole] OFF
/****** Object:  Table [dbo].[ShoppingCart]    Script Date: 05/09/2014 07:59:27 ******/
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
/****** Object:  Table [dbo].[Shipping]    Script Date: 05/09/2014 07:59:27 ******/
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
INSERT [dbo].[Shipping] ([RegionId], [RegionName], [RegionPrice], [DevMethods]) VALUES (3, N'Ottawa', 12.5, N'ups')
SET IDENTITY_INSERT [dbo].[Shipping] OFF
/****** Object:  Table [dbo].[RoleModule]    Script Date: 05/09/2014 07:59:27 ******/
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
/****** Object:  Table [dbo].[Role]    Script Date: 05/09/2014 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] NOT NULL,
	[RoleName] [varchar](255) NOT NULL,
	[Des] [varchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Role] ([RoleId], [RoleName], [Des]) VALUES (0, N'Admin', N'administrators')
INSERT [dbo].[Role] ([RoleId], [RoleName], [Des]) VALUES (1, N'User', N'customers')
/****** Object:  Table [dbo].[ResetPwds]    Script Date: 05/09/2014 07:59:27 ******/
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
/****** Object:  Table [dbo].[ProductPermission]    Script Date: 05/09/2014 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductPermission](
	[productId] [int] NOT NULL,
	[roleId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 05/09/2014 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Product](
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
 CONSTRAINT [PK_Product2] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderLine]    Script Date: 05/09/2014 07:59:27 ******/
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
/****** Object:  Table [dbo].[Order]    Script Date: 05/09/2014 07:59:27 ******/
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
/****** Object:  Table [dbo].[Inventory]    Script Date: 05/09/2014 07:59:27 ******/
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
/****** Object:  Table [dbo].[Discount]    Script Date: 05/09/2014 07:59:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[RoleId] [int] NOT NULL,
	[DisRate] [float] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 05/09/2014 07:59:27 ******/
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
