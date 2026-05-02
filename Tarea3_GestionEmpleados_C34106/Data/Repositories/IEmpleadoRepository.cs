using Tarea3_GestionEmpleados_C34106.Models;

namespace Tarea3_GestionEmpleados_C34106.Data.Repositories
{
    public interface IEmpleadoRepository
    {
        List<Empleado> ObtenerTodos();
        Empleado? ObtenerPorId(int id);
        List<Empleado> BuscarPorNombreODepartamento(string termino);
        List<Empleado> ObtenerPaginado(int pagina, int tamano, string? busqueda);
        int ContarTotal(string? busqueda);
        void Agregar(Empleado empleado);
        void Actualizar(Empleado empleado);
        void Eliminar(int id);
    }
}