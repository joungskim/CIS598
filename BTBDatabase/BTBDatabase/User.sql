﻿CREATE TABLE [dbo].[User]
(
	[User] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Image] IMAGE NULL, 
    [Bio] VARCHAR(5000) NULL, 
    [Age] INT NULL, 
    [Sex] NCHAR(1) NULL, 
	[State] NCHAR(2) NOT NULL,
    [Birthday] INT NULL, 
    [Date] date NULL 
)
