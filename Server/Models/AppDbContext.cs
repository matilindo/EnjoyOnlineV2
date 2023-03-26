using System.Collections.Generic;
using EnjoyOnline.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace EnjoyOnline.Server.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
        }

      
        public DbSet<Telefono> telefonos { get; set; } = null!;
        public DbSet<Empleado> empleados { get; set; } = null!;
    }
}


