using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnahiQuezadaBurgerMauiApp.Models
{
    internal class AQBurger
    {
        [Key]
        public int burgerId_JDS { get; set; }
        public string? name_JDS { get; set; }
        public bool withCheese_JDS { get; set; }
        public decimal precio_JDS { get; set; }
        public List<object>? promo_JDS { get; set; }
    }
}
