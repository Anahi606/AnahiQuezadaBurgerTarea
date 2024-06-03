using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AnahiQuezadaBurgerAPI.Data.Models;

namespace AnahiQuezadaBurgerAPI.Data
{
    public class AnahiQuezadaBurgerAPIContext : DbContext
    {
        public AnahiQuezadaBurgerAPIContext (DbContextOptions<AnahiQuezadaBurgerAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AnahiQuezadaBurgerAPI.Data.Models.AQBurger> AQBurger { get; set; } = default!;
        public DbSet<AnahiQuezadaBurgerAPI.Data.Models.AQPromo> AQPromo { get; set; } = default!;
    }
}
