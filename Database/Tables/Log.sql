﻿CREATE TABLE [dbo].[TblLog]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Text] NVARCHAR(50) NOT NULL,
	[Info] NVARCHAR(MAX) NULL,
	[Created] DATETIMEOFFSET (7) NOT NULL DEFAULT GETDATE()
)
