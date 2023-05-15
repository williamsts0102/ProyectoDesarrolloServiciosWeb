using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloServiciosWeb.Data;
using ProyectoDesarrolloServiciosWeb.Models;

namespace ProyectoDesarrolloServiciosWeb.Controllers
{
    public class CategoriaController : Controller
    {
        /*esta variable solo se puede asignar en el constructor de la clase*/
        private readonly ApplicationDbContext _db;
        public CategoriaController(ApplicationDbContext db){
            _db =db;
        }

        public IActionResult Index()
        {
            List<Categoria> listaCategoria = _db.categorias.ToList();

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
                _db.categorias.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Categoría creada con éxito";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if(id==null || id==0)
            {
                /*indica que la solicitud no se ha encontrado*/
                return NotFound();
            }

            Categoria? c = _db.categorias.Find(id);
            
            if(c==null)
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
                _db.categorias.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Categoría editada con éxito";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                /*indica que la solicitud no se ha encontrado*/
                return NotFound();
            }

            Categoria? c = _db.categorias.Find(id);
            if (c == null)
            {
                return NotFound();
            }

            return View(c);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Categoria? obj = _db.categorias.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.categorias.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Categoría eliminada con éxito";
            return RedirectToAction("Index");
        }
        

    }
}
