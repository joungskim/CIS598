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
        public List<Ingrediant> IngredientList { get; set; }
        public Ingrediant Ingredient { get; set; }
        public IngrediantRecipe Recipe {get; set;}
        public DrinkShot Drinkshot { get; set; }
    }
}