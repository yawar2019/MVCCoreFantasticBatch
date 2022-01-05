USE [master]
GO
/****** Object:  Database [eTill]    Script Date: 06-01-2022 01:11:25 ******/
CREATE DATABASE [eTill]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'eTill', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\eTill.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'eTill_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\eTill_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [eTill] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [eTill].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [eTill] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [eTill] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [eTill] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [eTill] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [eTill] SET ARITHABORT OFF 
GO
ALTER DATABASE [eTill] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [eTill] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [eTill] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [eTill] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [eTill] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [eTill] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [eTill] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [eTill] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [eTill] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [eTill] SET  DISABLE_BROKER 
GO
ALTER DATABASE [eTill] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [eTill] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [eTill] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [eTill] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [eTill] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [eTill] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [eTill] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [eTill] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [eTill] SET  MULTI_USER 
GO
ALTER DATABASE [eTill] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [eTill] SET DB_CHAINING OFF 
GO
ALTER DATABASE [eTill] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [eTill] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [eTill] SET DELAYED_DURABILITY = DISABLED 
GO
USE [eTill]
GO
/****** Object:  Table [dbo].[IPAddressName]    Script Date: 06-01-2022 01:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[IPAddressName](
	[IPAddress] [varchar](50) NULL,
	[Name] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[IPDetails]    Script Date: 06-01-2022 01:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IPDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[P_No] [int] NULL,
	[IPId] [int] NULL,
 CONSTRAINT [PK_IPDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Password]    Script Date: 06-01-2022 01:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Password](
	[P_NO] [int] NOT NULL,
	[P_USER] [varchar](50) NULL,
	[P_CODE] [varchar](15) NULL,
	[P_LEVEL] [int] NULL,
	[WEB_YN] [char](1) NULL,
	[WEB_PWORD] [varchar](15) NULL,
 CONSTRAINT [PK_Password] PRIMARY KEY CLUSTERED 
(
	[P_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserIPAddress]    Script Date: 06-01-2022 01:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserIPAddress](
	[IPId] [int] IDENTITY(1,1) NOT NULL,
	[P_IPAddress] [varchar](50) NULL,
	[UserName] [varchar](50) NULL,
	[Pwd] [varchar](50) NULL,
	[Location] [varchar](50) NULL,
 CONSTRAINT [PK_UserIPAddress] PRIMARY KEY CLUSTERED 
(
	[IPId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[IPAddressName] ([IPAddress], [Name]) VALUES (N'127.0.0.1', N'Bostwana')
INSERT [dbo].[IPAddressName] ([IPAddress], [Name]) VALUES (N'128.0.0.1', N'Hyderabad')
SET IDENTITY_INSERT [dbo].[IPDetails] ON 

INSERT [dbo].[IPDetails] ([id], [P_No], [IPId]) VALUES (1, 1, 1)
INSERT [dbo].[IPDetails] ([id], [P_No], [IPId]) VALUES (2, 1, 2)
SET IDENTITY_INSERT [dbo].[IPDetails] OFF
INSERT [dbo].[Password] ([P_NO], [P_USER], [P_CODE], [P_LEVEL], [WEB_YN], [WEB_PWORD]) VALUES (1, N'Imtiaz', N'1234', 9, N'Y', N'3456')
SET IDENTITY_INSERT [dbo].[UserIPAddress] ON 

INSERT [dbo].[UserIPAddress] ([IPId], [P_IPAddress], [UserName], [Pwd], [Location]) VALUES (1, N'41.75.7.146', N'root', N'toor', N'Bostwana')
INSERT [dbo].[UserIPAddress] ([IPId], [P_IPAddress], [UserName], [Pwd], [Location]) VALUES (2, N'128.0.0.1', NULL, N'9876', N'Hyderabad')
SET IDENTITY_INSERT [dbo].[UserIPAddress] OFF
/****** Object:  StoredProcedure [dbo].[usp_GetDbConnectionByIpaddress]    Script Date: 06-01-2022 01:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[usp_GetDbConnectionByIpaddress]
@Ipaddress varchar(50)
AS
BEGIN
select *  from [eTill].[dbo].[UserIPAddress]
 where P_IpAddress =@Ipaddress
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetIpByPNO]    Script Date: 06-01-2022 01:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_GetIpByPNO]
@PNO int
AS
BEGIN
select IPid,p_IpAddress as IpAddress,UserName,Pwd,location   from [eTill].[dbo].[UserIPAddress] where IPID in(select IPId  FROM [eTill].[dbo].[IPDetails] where P_No=@Pno)
END
GO
/****** Object:  StoredProcedure [dbo].[usp_Login]    Script Date: 06-01-2022 01:11:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[usp_Login](
@p_no int,
@Web_PWORD varchar(15)
 
)
As
BEGIN
 
 
SELECT * FROM Password where P_NO=@p_no and WEB_PWORD=@Web_PWORD
  
END
GO
USE [master]
GO
ALTER DATABASE [eTill] SET  READ_WRITE 
GO
