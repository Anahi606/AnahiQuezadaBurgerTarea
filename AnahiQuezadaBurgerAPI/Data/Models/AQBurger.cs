using System.ComponentModel.DataAnnotations;

namespace AnahiQuezadaBurgerAPI.Data.Models
{
    public class AQBurger
    {
        [Key]
        public int AQBurgerId { get; set; }

        public string AQName { get; set; } = null!;

        public bool AQWithCheese { get; set; }

        public decimal AQPrecio { get; set; }

        public virtual ICollection<AQPromo> AQPromo { get; set; } = new List<AQPromo>();
    }
}
