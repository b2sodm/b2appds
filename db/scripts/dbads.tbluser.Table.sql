USE [dbads]
GO
/****** Object:  Table [dbads].[tbluser]    Script Date: 2018/07/08 05:56:14 PM ******/
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
