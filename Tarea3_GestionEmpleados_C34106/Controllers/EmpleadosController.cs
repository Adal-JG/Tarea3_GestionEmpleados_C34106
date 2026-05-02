using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados_C34106.Data.Repositories;
using Tarea3_GestionEmpleados_C34106.Models;

namespace Tarea3_GestionEmpleados_C34106.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepository _repo;
        private const int TAMANO_PAGINA = 5;

        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }

        // INDEX con búsqueda y paginación
        public IActionResult Index(string? busqueda, int pagina = 1)
        {
            var empleados = _repo.ObtenerPaginado(pagina, TAMANO_PAGINA, busqueda);
            var totalRegistros = _repo.ContarTotal(busqueda);

            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / TAMANO_PAGINA);

            ViewBag.Busqueda = busqueda;
            ViewBag.PaginaActual = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            ViewBag.TotalRegistros = totalRegistros;

            return View(empleados);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // EDIT
        public IActionResult Edit(int id)
        {
            var empleado = _repo.ObtenerPorId(id);
            if (empleado == null) return NotFound();

            return View(empleado);
        }

        [HttpPost]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

        // TOGGLE ACTIVO (clave del enunciado)
        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                _repo.Actualizar(empleado);
            }

            return RedirectToAction("Index");
        }
    }
}