using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using System.Diagnostics;

namespace ProyectoDesarrolloServiciosWeb.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unit)
        {
            _logger = logger;
            _unit = unit;
        }

        public IActionResult Index()
        {
            IEnumerable<Producto> productoLista = _unit.Producto.GetAll(includeProperties:"Categoria");
            return View(productoLista);
        }

        public IActionResult Details(int productoId)
        {
            Producto producto = _unit.Producto.Get(u=>u.idProducto== productoId, includeProperties: "Categoria");
            return View(producto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}