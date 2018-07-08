USE [dbads]
GO
/****** Object:  Table [dbads].[tblcustomer]    Script Date: 2018/07/08 05:56:13 PM ******/
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
