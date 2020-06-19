using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//Model for the Home Index View
namespace CIS598PROJECT.Models
{
    public class HomeIndexModel
    {
        public List<DrinkShot> Drinkshot { get; set; }
    }
}