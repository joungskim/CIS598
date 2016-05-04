CREATE TABLE [dbo].[UserRating]
(
	[ID] int NOT NULL PRIMARY KEY,
	[DSName] NVARCHAR(50) NOT NULL,
	[SubmittedBy] NVARCHAR(50) NOT NULL,
	[Rating] int NOT NULL,
	[Description] VARCHAR(MAX) NOT NULL,
	[Date] date NOT NULL, 
	[Show]         BIT			  DEFAULT 1
)
