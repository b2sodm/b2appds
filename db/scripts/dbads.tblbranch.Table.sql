USE [dbads]
GO
/****** Object:  Table [dbads].[tblbranch]    Script Date: 2018/07/08 05:56:13 PM ******/
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
