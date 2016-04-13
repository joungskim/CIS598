CREATE TABLE [dbo].[User]
(
	[User] INT NOT NULL PRIMARY KEY, 
    [Email] NCHAR(10) NOT NULL, 
    [Image] IMAGE NULL, 
    [Bio] NCHAR(10) NULL, 
    [Age] INT NULL, 
    [Sex] NCHAR(1) NULL, 
	[State] NCHAR(2) NOT NULL,
    [Birthday] INT NULL, 
    [Date] INT NULL 
)
GO
CREATE TABLE [dbo].[Drink/Shot]
(
[Name] NCHAR(10) NOT NULL PRIMARY KEY,
[Submitted by] NCHAR(10) NOT NULL,
[Ingredients] NCHAR(50) NOT NULL,
[Instructions] NCHAR(50) NOT NULL
)
GO
CREATE TABLE [dbo].[Ingredients]
(
[Name] NCHAR(10) NOT NULL PRIMARY KEY,
[Description] NCHAR(50) NOT NULL,
[Image] IMAGE,
[Submitted By] NCHAR(10) NOT NULL,
[Cost/Liter] DECIMAL(2,2) NOT NULL,
[Date] INT NOT NULL,
[Type] NCHAR(10) NOT NULL
)
GO
CREATE TABLE [dbo].[MessageBoard]
(
[ID] NCHAR(10) NOT NULL PRIMARY KEY,
[Submitted By] NCHAR(10) NOT NULL,
[Description] NCHAR(50) NOT NULL,
[Date] INT NOT NULL,
[Image] IMAGE,
[Type] NCHAR(10)
)
GO
CREATE TABLE [dbo].[Messages]
(
[ID] NCHAR(10) NOT NULL PRIMARY KEY,
[From User] NCHAR(10) NOT NULL,
[To User] NCHAR(10) NOT NULL,
[Message] NCHAR(500) NOT NULL,
[Image] IMAGE,
[Date] int NOT NULL,
[Show] int NOT NULL
)
GO
CREATE TABLE [dbo].[User Rating]
(
[ID] NCHAR(10) NOT NULL PRIMARY KEY,
[DBI Name] NCHAR(10) NOT NULL FOREIGN KEY,
[Submitted By] NCHAR(10) NOT NULL FOREIGN KEY,
[Rating] FLOAT NOT NULL,
[Description] NCHAR(50) NOT NULL,
[Date] INT NOT NULL
)
GO
CREATE TABLE [dbo].[Replies]
(
[ID] NCHAR(10) NOT NULL PRIMARY KEY,
[MBID] NCHAR(10) NOT NULL, FOREIGN KEY,
[Description] NCHAR(50) NOT NULL,
[Date] INT NOT NULL,
[Submitted By] NCHAR(10) NOT NULL, FOREIGN KEY,
[Image] IMAGE
)
