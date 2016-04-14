CREATE TABLE [dbo].[MessageBoard]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[SubmittedBy] NVARCHAR(50) NOT NULL,
	[Description] VARCHAR(MAX) NOT NULL,
	[Date] datetime NOT NULL,
	[Image] IMAGE,
	[Type] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_MessageBoard_ToTable] FOREIGN KEY ([SubmittedBy]) REFERENCES [dbo].[User]([User])
)

