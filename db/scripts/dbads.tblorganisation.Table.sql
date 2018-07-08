USE [dbads]
GO
/****** Object:  Table [dbads].[tblorganisation]    Script Date: 2018/07/08 05:56:14 PM ******/
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
