 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoDesarrolloServiciosWeb.DataAccess.Repository.IRepository;
using ProyectoDesarrolloServiciosWeb.Models;
using ProyectoDesarrolloServiciosWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using ProyectoDesarrolloServiciosWeb.Utility;

namespace ProyectoDesarrolloServiciosWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductoController : Controller
    {
        /*esta variable solo se puede asignar en el constructor de la clase*/
        /*camabiaremos*/
        private readonly IUnitOfWork _unit;

        /*para obtener rutas de archivos; ya que proporciona propiedades como WebRootPath y ContentRootPath*/
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductoController(IUnitOfWork unit, IWebHostEnvironment webHostEnvironment)
        {
            _unit = unit;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            /*categoria es de la entidad*/
            List<Producto> listaProducto = _unit.Producto.GetAll(includeProperties:"Categoria").ToList();
            
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
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productoPath = Path.Combine(wwwRootPath, @"imagenes\productos");

                    if (!string.IsNullOrEmpty(productvm.producto.ImageUrl))
                    {
                        var oldImagenPath = Path.Combine(wwwRootPath, productvm.producto.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagenPath)) { System.IO.File.Delete(oldImagenPath); }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productoPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productvm.producto.ImageUrl = @"\imagenes\productos\" + fileName;
                }

                if (productvm.producto.idProducto == 0)
                {
                    _unit.Producto.Add(productvm.producto);
                }
                else
                {
                    _unit.Producto.Update(productvm.producto);
                }

                _unit.Save();
                TempData["succes"] = "Producto registrado";
                return RedirectToAction("Index");
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

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Producto> listaProducto = _unit.Producto.GetAll(includeProperties: "Categoria").ToList();
            return Json(new { data = listaProducto });
        }

        [HttpDelete] public IActionResult Delete(int idProducto)
        {
            var productoToBeDeleted = _unit.Producto.Get(u => u.idProducto == idProducto);
            if (productoToBeDeleted == null)
            {
                return Json(new {success = false , messsage = "Error al intentar eliminar."});
            }
            var oldImagenPath = Path.Combine(_webHostEnvironment.WebRootPath, 
                productoToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagenPath)) 
            { System.IO.File.Delete(oldImagenPath); }

            _unit.Producto.Remove(productoToBeDeleted);
            _unit.Save();

            return Json(new { succes = true, message = "Eliminación Exitosa" });
        }

        #endregion

    }
}
