﻿CREATE TABLE [dbo].[Ingredients]
(
	[Name] NVARCHAR(50) NOT NULL PRIMARY KEY,
	[Description] NVARCHAR(MAX) NOT NULL,
	[Image] IMAGE,
	[SubmittedBy] NVARCHAR(50) NOT NULL,
	[CostLiter] money NULL,
	[Date] date NOT NULL,
	[Type] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Ingredients_ToTable] FOREIGN KEY ([SubmittedBy]) REFERENCES [dbo].[User]([User])
)

