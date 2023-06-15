using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using System.Diagnostics;
using System.Security.Claims;

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
            CarritoCompras carrito = new()
            {
                 Producto = _unit.Producto.Get(u=>u.idProducto== productoId, includeProperties: "Categoria"),
                Cantidad = 1,
                ProductoId=productoId
            };
            return View(carrito);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(CarritoCompras carritoCompras)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            carritoCompras.ApplicationUserId = userId;

            CarritoCompras carritoDb = _unit.Carrito.Get(u=>u.ApplicationUserId==userId &&
            u.ProductoId==carritoCompras.ProductoId);

            if (carritoDb != null)
            {

                carritoDb.Cantidad += carritoCompras.Cantidad;
                _unit.Carrito.Update(carritoDb);
            }
            else
            {
                _unit.Carrito.Add(carritoCompras);
            }

            TempData["succes"] = "Carrito actualizado";
            _unit.Save();

            return RedirectToAction(nameof(Index));
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