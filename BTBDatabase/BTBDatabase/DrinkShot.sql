CREATE TABLE [dbo].[DrinkShot]
(
	[Name] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[SubmittedBy] NVARCHAR(50) NOT NULL,
	[Instructions] NVARCHAR(MAX) NOT NULL,
	[RatingTotal] int,
	[ViewCount] int,
	[Image] image,
	[Cost] money,
	[Date] DATETIME2 NOT NULL,
	[Type] nchar(10) NOT NULL, 
    CONSTRAINT [FK_DrinkShot_ToTable] FOREIGN KEY ([SubmittedBy]) REFERENCES [dbo].[User]([User]) ON DELETE CASCADE
)

