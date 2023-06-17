using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using ProyectoDesarrolloServiciosWeb.Models.ViewModels;
using ProyectoDesarrolloServiciosWeb.Utility;
using System.Security.Claims;

namespace ProyectoDesarrolloServiciosWeb.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    [Authorize]
    public class CarritoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
        public CarritoComprasVM carritoComprasVM { get; set; }

        public CarritoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            carritoComprasVM = new()
            {
                carritoList = _unitOfWork.Carrito.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "Producto"),
                OrderHeader = new()
            };

            foreach (var carrito in carritoComprasVM.carritoList)
            {
                carrito.Precio = carrito.Producto.precio;
                carritoComprasVM.OrderHeader.TotalPedido += carrito.Precio * carrito.Cantidad;
            }

            return View(carritoComprasVM);
        }

        public IActionResult Aumentar(int carritoId)
        {
            var cartFromDb = _unitOfWork.Carrito.Get(u => u.Id == carritoId);
            cartFromDb.Cantidad += 1;
            _unitOfWork.Carrito.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Disminuir(int carritoId)
        {
            var cartFromDb = _unitOfWork.Carrito.Get(u => u.Id == carritoId);
            if (cartFromDb.Cantidad <= 1)
            {
                _unitOfWork.Carrito.Remove(cartFromDb);
            }
            else
            {
                cartFromDb.Cantidad -= 1;
                _unitOfWork.Carrito.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Eliminar(int carritoId)
        {
            var cartFromDb = _unitOfWork.Carrito.Get(u => u.Id == carritoId);

            _unitOfWork.Carrito.Remove(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Sumar()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            carritoComprasVM  = new()
            {
                carritoList = _unitOfWork.Carrito.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "Producto"),
                OrderHeader = new()
            };

            carritoComprasVM.OrderHeader.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
            carritoComprasVM.OrderHeader.Nombre = carritoComprasVM.OrderHeader.ApplicationUser.Nombre;
            carritoComprasVM.OrderHeader.Telefono = carritoComprasVM.OrderHeader.ApplicationUser.Telefono;
            carritoComprasVM.OrderHeader.Direccion = carritoComprasVM.OrderHeader.ApplicationUser.Direccion;
            carritoComprasVM.OrderHeader.Ciudad = carritoComprasVM.OrderHeader.ApplicationUser.Ciudad;
            carritoComprasVM.OrderHeader.CodigoPostal = carritoComprasVM.OrderHeader.ApplicationUser.CodigoPostal;
           
            foreach (var carrito in carritoComprasVM.carritoList)
            {
                carrito.Precio = carrito.Producto.precio;
                carritoComprasVM.OrderHeader.TotalPedido += carrito.Precio * carrito.Cantidad;
            }

            return View(carritoComprasVM);
        }

		[HttpPost]
		[ActionName("Sumar")]
		public IActionResult SumarPost()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			carritoComprasVM.carritoList = _unitOfWork.Carrito.GetAll(u => u.ApplicationUserId == userId,
				includeProperties: "Producto");

			carritoComprasVM.OrderHeader.FechaOrden = System.DateTime.Now;
			carritoComprasVM.OrderHeader.ApplicationUserId = userId;

			foreach (var carrito in carritoComprasVM.carritoList)
			{
				carrito.Precio = carrito.Producto.precio;
				carritoComprasVM.OrderHeader.TotalPedido += carrito.Precio * carrito.Cantidad;
			}
            if (carritoComprasVM.OrderHeader.ApplicationUser.CompanyId.GetValueOrDefault() == 0)
            {
                carritoComprasVM.OrderHeader.EstadoPago = SD.EstadoPagoPendiente;
				carritoComprasVM.OrderHeader.EstadoPedido = SD.EstadoPendiente;
			}
            else{
				carritoComprasVM.OrderHeader.EstadoPago = SD.PagoEstadoRetrasado;
				carritoComprasVM.OrderHeader.EstadoPedido = SD.EstadoPendiente;
			}
            _unitOfWork.OrderHeader.Add(carritoComprasVM.OrderHeader);
            _unitOfWork.Save();
            foreach(var cart in carritoComprasVM.carritoList)
            {
                OrderDetalle orderDetalle = new()
                {
                    ProductId = cart.ProductoId,
                    OrderHeaderId = carritoComprasVM.OrderHeader.Id,
                    Precio = cart.Precio,
                    Cantidad = cart.Cantidad
                };
                _unitOfWork.OrderDetalles.Add(orderDetalle);
                _unitOfWork.Save();
            }
			if (carritoComprasVM.OrderHeader.ApplicationUser.CompanyId.GetValueOrDefault() == 0)
			{
			}

			return View(carritoComprasVM);
		}

        public IActionResult ConfirmarOrden(int id)
        {
            return View(id);
        }




	}
}
