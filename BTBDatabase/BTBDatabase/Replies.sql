CREATE TABLE [dbo].[Replies]
(
[ID] int NOT NULL PRIMARY KEY,
[MBID] int NOT NULL,
[Description] VARCHAR(5000) NOT NULL,
[Date] datetime NOT NULL,
[SubmittedBy] NVARCHAR(50) NOT NULL,
[Image] IMAGE, 
[Show]         BIT			  DEFAULT 1
)
