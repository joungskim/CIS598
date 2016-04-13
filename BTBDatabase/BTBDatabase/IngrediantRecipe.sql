CREATE TABLE [dbo].[IngrediantRecipe]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[DSName] nvarchar(50) NOT Null,
	[IngrediantName] nvarchar(50) not null,
	[Ounces] decimal not null, 
    CONSTRAINT [FK_IngrediantRecipe_ToTable] FOREIGN KEY ([DSName]) REFERENCES [dbo].[DrinkShot]([Name]), 
    CONSTRAINT [FK_IngrediantRecipe_ToTable_1] FOREIGN KEY ([IngrediantName]) REFERENCES [dbo].[Ingrediants]([Name])
)
