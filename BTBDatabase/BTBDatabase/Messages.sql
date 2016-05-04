CREATE TABLE [dbo].[Messages]
(
[ID] int NOT NULL PRIMARY KEY,
[FromUser] NVARCHAR(50) NOT NULL,
[ToUser] NVARCHAR(50) NOT NULL,
[Message] VARCHAR(MAX) NOT NULL,
[Image] IMAGE,
[Date] datetime NOT NULL,
[Show] INT NOT NULL, 
)
