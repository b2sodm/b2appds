
/****** Object:  Database [dbads]    Script Date: 2018/07/08 04:56:26 PM ******/
CREATE DATABASE [dbads]
GO
ALTER DATABASE [dbads] SET COMPATIBILITY_LEVEL = 110
GO
ALTER DATABASE [dbads] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbads] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbads] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbads] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbads] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbads] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [dbads] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [dbads] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbads] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbads] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbads] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbads] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbads] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbads] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbads] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbads] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dbads] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbads] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbads] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbads] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbads] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbads] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbads] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbads] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbads] SET  MULTI_USER 
GO
ALTER DATABASE [dbads] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbads] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbads] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbads] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [dbads]
GO
/****** Object:  User [dbads]    Script Date: 2018/07/08 04:56:28 PM ******/
CREATE USER [dbads] FOR LOGIN [newp4] WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [dbads]
GO
ALTER ROLE [db_datareader] ADD MEMBER [dbads]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [dbads]
GO
/****** Object:  Schema [dbads]    Script Date: 2018/07/08 04:56:29 PM ******/
CREATE SCHEMA [dbads]
GO
/****** Object:  Table [dbads].[tblbranch]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tblbranch](
	[bracode] [int] NOT NULL,
	[braname] [nvarchar](30) NOT NULL,
	[orgcode] [nvarchar](30) NULL,
	[orgname] [nvarchar](30) NOT NULL,
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[info] [datetime] NOT NULL,
	[ptype] [nvarchar](30) NOT NULL,
	[puser] [int] NULL,
	[notes] [text] NULL,
 CONSTRAINT [PK_tblbranch] PRIMARY KEY CLUSTERED 
(
	[bracode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbads].[tblbranchuser]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tblbranchuser](
	[ucode] [int] NOT NULL,
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[info] [datetime] NOT NULL,
	[ptype] [nvarchar](30) NOT NULL,
	[organisation] [nvarchar](50) NOT NULL,
	[branch] [nvarchar](50) NOT NULL,
	[disabled] [nvarchar](1) NULL,
	[notes] [text] NULL,
 CONSTRAINT [PK_tblbranchuser] PRIMARY KEY CLUSTERED 
(
	[ucode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbads].[tblcustomer]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tblcustomer](
	[ccode] [int] NOT NULL,
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[surname] [nvarchar](30) NULL,
	[email] [nvarchar](50) NULL,
	[info] [datetime] NULL,
	[organisation] [nvarchar](50) NOT NULL,
	[branch] [nvarchar](50) NULL,
	[disabled] [nvarchar](1) NULL,
	[notes] [text] NULL,
 CONSTRAINT [PK_tblcustomer] PRIMARY KEY CLUSTERED 
(
	[ccode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbads].[tblmessage]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tblmessage](
	[mcode] [int] NOT NULL,
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[psurname] [nvarchar](30) NULL,
	[email] [nvarchar](50) NULL,
	[type] [nvarchar](30) NOT NULL,
	[info] [datetime] NULL,
	[organisation] [nvarchar](50) NOT NULL,
	[branch] [nvarchar](50) NULL,
	[message] [text] NOT NULL,
	[notes] [text] NULL,
 CONSTRAINT [PK_tblmessage] PRIMARY KEY CLUSTERED 
(
	[mcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbads].[tblorganisation]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tblorganisation](
	[orgcode] [int] NOT NULL,
	[orgname] [nvarchar](30) NOT NULL,
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[info] [datetime] NOT NULL,
	[ptype] [nvarchar](30) NOT NULL,
	[branch] [int] NULL,
	[notes] [text] NULL,
 CONSTRAINT [PK_tblorganisation] PRIMARY KEY CLUSTERED 
(
	[orgcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbads].[tblorguser]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tblorguser](
	[ucode] [int] NOT NULL,
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[info] [datetime] NOT NULL,
	[ptype] [nvarchar](30) NOT NULL,
	[organisation] [nvarchar](50) NOT NULL,
	[branch] [nvarchar](50) NULL,
	[disabled] [nvarchar](1) NULL,
	[notes] [text] NULL,
 CONSTRAINT [PK_tblorguser] PRIMARY KEY CLUSTERED 
(
	[ucode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbads].[tbluser]    Script Date: 2018/07/08 04:56:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbads].[tbluser](
	[pcode] [int] NOT NULL,
	[pname] [nvarchar](30) NOT NULL,
	[surname] [nvarchar](30) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[poption] [nvarchar](30) NOT NULL,
	[info] [datetime] NOT NULL,
	[password] [nvarchar](130) NOT NULL,
	[organisation] [nvarchar](50) NULL,
	[branch] [nvarchar](50) NULL,
	[online] [nvarchar](1) NULL,
	[notes] [text] NULL,
	[active] [nvarchar](1) NULL,
 CONSTRAINT [PK_tbluser] PRIMARY KEY CLUSTERED 
(
	[pcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER DATABASE [dbads] SET  READ_WRITE 
GO
