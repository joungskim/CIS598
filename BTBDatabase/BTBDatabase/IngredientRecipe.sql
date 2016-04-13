CREATE TABLE [dbo].[IngredientRecipe]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[DSName] nvarchar(50) NOT Null,
	[IngredientName] nvarchar(50) not null,
	[Ounces] decimal not null, 
    CONSTRAINT [FK_IngredientRecipe_ToTable] FOREIGN KEY ([DSName]) REFERENCES [dbo].[DrinkShot]([Name]), 
    CONSTRAINT [FK_IngredientRecipe_ToTable_1] FOREIGN KEY ([IngredientName]) REFERENCES [dbo].[Ingredients]([Name])
)
