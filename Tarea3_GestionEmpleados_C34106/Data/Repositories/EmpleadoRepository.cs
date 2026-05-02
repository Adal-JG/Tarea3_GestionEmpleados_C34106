using Tarea3_GestionEmpleados_C34106.Models;

namespace Tarea3_GestionEmpleados_C34106.Data.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Empleado> ObtenerTodos()
        {
            return _context.Empleados
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        public Empleado? ObtenerPorId(int id)
        {
            return _context.Empleados.Find(id);
        }

        public List<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            termino = termino.ToLower();

            return _context.Empleados
                .Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino))
                .OrderBy(e => e.Nombre)
                .ToList();
        }

        public List<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string termino = busqueda.ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino));
            }

            return query
                .OrderBy(e => e.Nombre)
                .Skip((pagina - 1) * tamano)
                .Take(tamano)
                .ToList();
        }

        public int ContarTotal(string? busqueda)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(busqueda))
            {
                string termino = busqueda.ToLower();

                query = query.Where(e =>
                    e.Nombre.ToLower().Contains(termino) ||
                    e.Apellidos.ToLower().Contains(termino) ||
                    e.Departamento.ToLower().Contains(termino));
            }

            return query.Count();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var empleado = ObtenerPorId(id);

            if (empleado != null)
            {
                empleado.Activo = false;
                _context.SaveChanges();
            }
        }
    }
}