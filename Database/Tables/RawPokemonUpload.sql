-- Since in this exercise there's only one file we are dealing with we probably don't need this table. But I love to log when I can because I found it to be useful to have the data somewhere. Especially when you need to debug something.
-- I'm going to keep 90% of this table nullable & string inputs since it's a raw upload. Would rather get the data than not if it fails.
CREATE TABLE [dbo].[TblRawPokemonUpload](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] NVARCHAR(50) NULL,
	[PokemonId] NVARCHAR(20) NULL,
	[PokemonName] NVARCHAR(50) NULL,
	[PokemonType1] NVARCHAR(20) NULL,
	[PokemonType2] NVARCHAR(20) NULL,
	[PokemonTotal] NVARCHAR(20) NULL,
	[PokemonHP] NVARCHAR(20) NULL,
	[PokemonAttack] NVARCHAR(20) NULL,
	[PokemonDefense] NVARCHAR(20) NULL,
	[PokemonSpAttack] NVARCHAR(20) NULL,
	[PokemonSpDefense] NVARCHAR(20) NULL,
	[PokemonSpeed] NVARCHAR(20) NULL,
	[Generation] NVARCHAR(10) NULL,
	[Legendary] NVARCHAR(10) NULL,
	[Created] [DATETIMEOFFSET] (7) DEFAULT GETDATE() NOT NULL,
 CONSTRAINT [PK_TblZendeskTicket] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
