﻿CREATE TABLE [dbo].[TblPokemon]
(
	[RecordId] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Id] INT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[Type1] NVARCHAR(20) NOT NULL,
	[Type2] NVARCHAR(20) NULL,
	[Total] INT NOT NULL,
	[HP] INT NOT NULL,
	[Attack] INT NOT NULL,
	[Defense] INT NOT NULL,
	[SpAttack] INT NOT NULL,
	[SpDefense] INT NOT NULL,
	[Speed] INT NOT NULL,
	[Generation] INT NOT NULL,
	[Legendary] BIT NOT NULL,
	[Modified] [DATETIMEOFFSET] (7) NULL,
	[Created] [DATETIMEOFFSET] (7) DEFAULT GETDATE() NOT NULL,
	[Active] BIT NOT NULL
)
