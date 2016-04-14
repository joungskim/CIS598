CREATE TABLE [dbo].[Replies]
(
[ID] int NOT NULL PRIMARY KEY,
[MBID] int NOT NULL,
[Description] VARCHAR(5000) NOT NULL,
[Date] datetime NOT NULL,
[SubmittedBy] NVARCHAR(50) NOT NULL,
[Image] IMAGE, 
    CONSTRAINT [FK_Replies_ToTable] FOREIGN KEY ([MBID]) REFERENCES [dbo].[MessageBoard]([Id]), 
    CONSTRAINT [FK_Replies_ToTable_1] FOREIGN KEY ([SubmittedBy]) REFERENCES [dbo].[User]([User])
)
