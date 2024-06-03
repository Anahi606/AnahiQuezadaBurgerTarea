using System.ComponentModel.DataAnnotations;

namespace AnahiQuezadaBurgerTarea.Models
{
    public class AQPromo
    {
        [Key]
        public int AQPromoId { get; set; }

        [Required]
        public string? AQDescripcion { get; set; }

        [Required]
        public DateTime AQFechaPromo { get; set; }

        public int AQBurgerId { get; set; }

        public AQBurger? AQBurger { get; set; }
    }
}


