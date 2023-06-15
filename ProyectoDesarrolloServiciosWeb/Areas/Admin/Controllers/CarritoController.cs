using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoDesarrolloServiciosWeb.Areas.Admin.Controllers
{
    public class CarritoController : Controller
    {
        [Area("Cliente")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
