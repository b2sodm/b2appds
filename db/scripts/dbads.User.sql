USE [dbads]
GO
/****** Object:  User [dbads]    Script Date: 2018/07/08 05:56:13 PM ******/
CREATE USER [dbads] FOR LOGIN [newp4] WITH DEFAULT_SCHEMA=[db_owner]
GO
ALTER ROLE [db_owner] ADD MEMBER [dbads]
GO
ALTER ROLE [db_datareader] ADD MEMBER [dbads]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [dbads]
GO
