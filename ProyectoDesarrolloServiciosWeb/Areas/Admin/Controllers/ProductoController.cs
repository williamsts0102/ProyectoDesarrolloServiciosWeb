 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using ProyectoDesarrolloServiciosWeb.Models.ViewModels;

namespace ProyectoDesarrolloServiciosWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductoController : Controller
    {
        /*esta variable solo se puede asignar en el constructor de la clase*/
        /*camabiaremos*/
        private readonly IUnitOfWork _unit;
        public ProductoController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            List<Producto> listaProducto = _unit.Producto.GetAll().ToList();
            
            return View(listaProducto);
        }

        public IActionResult Upsert(int? idProducto)
        {
            ProductVM productvm = new()
            {
                listacat = _unit.Categoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.nombre,
                    Value = u.idCategoria.ToString()
                }),
                producto = new Producto()
            };

            /*aqui haremos un metodo actualizar: pero debemos enviarle un parametro*/
            /*si id es 0 o nulo*/
            /*agregara*/
            if(idProducto==null || idProducto == 0)
            {
                return View(productvm);
            }
            else
            {
                /*actualizar*/
                productvm.producto = _unit.Producto.Get(u=>u.idProducto==idProducto);
                return View(productvm);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM productvm, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (productvm.producto.idProducto==0)
                {
                    _unit.Producto.Add(productvm.producto);
                    _unit.Save();
                    TempData["success"] = "Producto creada con éxito"; /*Para mandar un valor temporal en este caso un texto*/
                    return RedirectToAction("Index");
                }
                else
                {
                    _unit.Producto.Update(productvm.producto);
                    _unit.Save();
                    TempData["success"] = "Producto actualizado con éxito"; /*Para mandar un valor temporal en este caso un texto*/
                    return RedirectToAction("Index");
                }
                
            }
            else
            {
                productvm.listacat = _unit.Categoria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.nombre,
                    Value = u.idCategoria.ToString()
                });
                return View(productvm);
            }
           
        }


        
        public IActionResult Delete(int? idProducto)
        {
            if (idProducto == null || idProducto == 0)
            {
                /*indica que la solicitud no se ha encontrado*/
                return NotFound();
            }

            Producto? p = _unit.Producto.Get(u => u.idProducto == idProducto);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? idProducto)
        {
            Producto? obj = _unit.Producto.Get(u => u.idProducto == idProducto);

            if (obj == null)
            {
                return NotFound();
            }
            _unit.Producto.Remove(obj);
            _unit.Save();
            TempData["success"] = "Producto eliminada con éxito";/*Para mandar un valor temporal en este caso un texto*/
            return RedirectToAction("Index");
        }
    }
}
