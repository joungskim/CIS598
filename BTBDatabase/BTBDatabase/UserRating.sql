CREATE TABLE [dbo].[UserRating]
(
	[ID] int NOT NULL PRIMARY KEY,
	[DSName] NVARCHAR(50) NOT NULL,
	[SubmittedBy] NVARCHAR(50) NOT NULL,
	[Rating] int NOT NULL,
	[Description] VARCHAR(MAX) NOT NULL,
	[Date] date NOT NULL, 
    CONSTRAINT [FK_UserRating_ToTable] FOREIGN KEY ([DSName]) REFERENCES [dbo].[DrinkShot]([Name]), 
    CONSTRAINT [FK_UserRating_ToTable_1] FOREIGN KEY ([SubmittedBy]) REFERENCES [dbo].[User]([User])
)
