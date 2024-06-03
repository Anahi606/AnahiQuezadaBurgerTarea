using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnahiQuezadaBurgerTarea.Models;

namespace AnahiQuezadaBurgerTarea.Data
{
    public class AnahiQuezadaBurgerTareaContext : DbContext
    {
        public AnahiQuezadaBurgerTareaContext (DbContextOptions<AnahiQuezadaBurgerTareaContext> options)
            : base(options)
        {
        }

        public DbSet<AnahiQuezadaBurgerTarea.Models.AQBurger> AQBurger { get; set; } = default!;
        public DbSet<AnahiQuezadaBurgerTarea.Models.AQPromo> AQPromo { get; set; } = default!;
    }
}
