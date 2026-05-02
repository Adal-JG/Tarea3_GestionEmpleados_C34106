using Microsoft.EntityFrameworkCore;
using Tarea3_GestionEmpleados_C34106.Models;

namespace Tarea3_GestionEmpleados_C34106.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}