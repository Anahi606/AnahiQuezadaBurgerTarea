using System.ComponentModel.DataAnnotations;

namespace AnahiQuezadaBurgerTarea.Models
{
    public class AQBurger
    {
        [Key]
        public int AQBurgerId { get; set; }
        [Required]
        public string? AQName { get; set; }
        public bool AQWithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal AQPrecio { get; set; }

        public List<AQPromo>? AQPromo { get; set; }


        public class VerificarRango : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                if ((decimal)value < 1 || (decimal)value > 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}