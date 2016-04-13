CREATE TABLE [dbo].[Messages]
(
[ID] int NOT NULL PRIMARY KEY,
[FromUser] NVARCHAR(50) NOT NULL,
[ToUser] NVARCHAR(50) NOT NULL,
[Message] VARCHAR(MAX) NOT NULL,
[Image] IMAGE,
[Date] datetime NOT NULL,
[Show] INT NOT NULL, 
    CONSTRAINT [FK_Messages_ToTable] FOREIGN KEY ([FromUser]) REFERENCES [dbo].[User]([User]), 
    CONSTRAINT [FK_Messages_ToTable_1] FOREIGN KEY ([ToUser]) REFERENCES [dbo].[User]([User])
)
