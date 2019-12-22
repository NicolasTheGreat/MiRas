USE [master]
GO
CREATE LOGIN [Administrator] WITH PASSWORD=N'Administrator1', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [MiRas]
GO
CREATE USER [Administrator] FOR LOGIN [Administrator]
GO
USE [MiRas]
GO
ALTER ROLE [Administrator_role] ADD MEMBER [Administrator]
GO
