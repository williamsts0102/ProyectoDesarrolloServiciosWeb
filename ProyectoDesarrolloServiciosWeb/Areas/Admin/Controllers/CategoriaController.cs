using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloServiciosWeb.DataAccess.Data;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using Microsoft.AspNetCore.Authorization;
using ProyectoDesarrolloServiciosWeb.Utility;

namespace ProyectoDesarrolloServiciosWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles=SD.Role_Admin)]

    public class CategoriaController : Controller
    {
        /*esta variable solo se puede asignar en el constructor de la clase*/
        /*camabiaremos*/
        private readonly IUnitOfWork _unit;
        public CategoriaController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            List<Categoria> listaCategoria = _unit.Categoria.GetAll().ToList();

            return View(listaCategoria);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria obj)
        {
            if (obj.nombre == obj.DisplayOrder.ToString())
            {
                //el name es porque asi se llama el atributo
                ModelState.AddModelError("nombre", "El orden de visualización no puede ser igual que el Nombre");
            }

            if (ModelState.IsValid)
            {
                _unit.Categoria.Add(obj);
                _unit.Save();
                TempData["success"] = "Categoría creada con éxito"; /*Para mandar un valor temporal en este caso un texto*/
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int? idCategoria)
        {
            if (idCategoria == null || idCategoria == 0)
            {
                /*indica que la solicitud no se ha encontrado*/
                return NotFound();
            }

            Categoria? c = _unit.Categoria.Get(u => u.idCategoria == idCategoria);

            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        [HttpPost]
        public IActionResult Edit(Categoria obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Categoria.Update(obj);
                _unit.Save();
                TempData["success"] = "Categoría editada con éxito";/*Para mandar un valor temporal en este caso un texto*/
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? idCategoria)
        {
            if (idCategoria == null || idCategoria == 0)
            {
                /*indica que la solicitud no se ha encontrado*/
                return NotFound();
            }

            Categoria? c = _unit.Categoria.Get(u => u.idCategoria == idCategoria);
            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? idCategoria)
        {
            Categoria? obj = _unit.Categoria.Get(u => u.idCategoria == idCategoria);

            if (obj == null)
            {
                return NotFound();
            }
            _unit.Categoria.Remove(obj);
            _unit.Save();
            TempData["success"] = "Categoría eliminada con éxito";/*Para mandar un valor temporal en este caso un texto*/
            return RedirectToAction("Index");
        }


    }
}
