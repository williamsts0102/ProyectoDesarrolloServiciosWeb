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
    public class CompanyController : Controller
    {
        /*esta variable solo se puede asignar en el constructor de la clase*/
        /*camabiaremos*/
        private readonly IUnitOfWork _unit;

        public CompanyController(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public IActionResult Index()
        {
            /*categoria es de la entidad*/
            List<Company> listaCompany = _unit.Company.GetAll().ToList();
            
            return View(listaCompany);
        }

        public IActionResult Upsert(int? id)
        {
            /*aqui haremos un metodo actualizar: pero debemos enviarle un parametro*/
            /*si id es 0 o nulo*/
            /*agregara*/
            if(id==null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                /*actualizar*/
                Company objCompany = _unit.Company.Get(u=>u.Id==id);
                return View(objCompany);
            }

        }

        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
                if (companyObj.Id == 0)
                {
                    _unit.Company.Add(companyObj);
                }
                else
                {
                    _unit.Company.Update(companyObj);
                }

                _unit.Save();
                TempData["succes"] = "Company registrado";
                return RedirectToAction("Index");
            }
            else
            {
                return View(companyObj);
            }
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> listaCompany = _unit.Company.GetAll().ToList();
            return Json(new { data = listaCompany });
        }

        [HttpDelete] public IActionResult Delete(int id)
        {
            var CompanyToBeDeleted = _unit.Company.Get(u => u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new {success = false , messsage = "Error al intentar eliminar."});
            }
          
            _unit.Company.Remove(CompanyToBeDeleted);
            _unit.Save();

            return Json(new { succes = true, message = "Eliminación Exitosa" });
        }

        #endregion

    }
}
