using System.ComponentModel.DataAnnotations;

namespace AnahiQuezadaBurgerAPI.Data.Models
{
    public class AQPromo
    {
        [Key]
        public int AQPromoId { get; set; }

        public string AQDescripcion { get; set; } = null!;

        public DateTime AQFechaPromo { get; set; }

        public int AQBurgerId { get; set; }

        public virtual AQBurger? AQBurger { get; set; }
    }
}
