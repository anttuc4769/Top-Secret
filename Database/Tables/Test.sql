-- Just a table to test if code/db are connected and log random things during initial setup of other tables. 
CREATE TABLE [dbo].[TblTest]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[Text] NVARCHAR(50) NOT NULL
)
