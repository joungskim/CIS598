using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CIS598PROJECT.Models
{
    public class DSCreateModel
    {
        public string[] SelectedIngredients { get; set; }
        public List<Ingredient> IngredientList { get; set; }
        public Ingredient Ingredient { get; set; }
        public IngredientRecipe Recipe {get; set;}
        public DrinkShot Drinkshot { get; set; }
    }
}