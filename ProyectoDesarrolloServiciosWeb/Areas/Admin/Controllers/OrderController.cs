using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using ProyectoDesarrolloServiciosWeb.Utility;

namespace ProyectoDesarrolloServiciosWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			return View();
		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAll(string status)
		{
			IEnumerable<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();

			switch (status)
			{
				case "pendiente":
					objOrderHeaders = objOrderHeaders.Where(u => u.EstadoPago == SD.PagoEstadoRetrasado);
					break;
				case "enproceso":
					objOrderHeaders = objOrderHeaders.Where(u => u.EstadoPedido == SD.EstadoProceso);
					break;
				case "completado":
					objOrderHeaders = objOrderHeaders.Where(u => u.EstadoPedido == SD.EstadoEnviado);
					break;
				case "aprobado":
					objOrderHeaders = objOrderHeaders.Where(u => u.EstadoPedido ==SD.EstadoAprobado);
					break;
				default:
					break;
			}

                    return Json(new { data = objOrderHeaders });
		}
		#endregion

	}
}
