
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
       
        public CompanyController(IUnitOfWork db)
        {
            _UnitOfWork = db;
        }
        public IActionResult Index()
        {
            List<Company> companiesList = _UnitOfWork.Company.GetAll().ToList();

            return View(companiesList);
        }
        public IActionResult Upsert(int? id)
        {
            if (id == 0 || id == null)
            {
                return View(new Company());
            }
            else
            {
                 Company companyObj = _UnitOfWork.Company.Get(u => u.Id == id);
                return View(companyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company companyObj)
        {
            if (ModelState.IsValid)
            {
              
                if (companyObj.Id == 0)
                {
                    _UnitOfWork.Company.Add(companyObj);
                }
                else
                {
                    _UnitOfWork.Company.Update(companyObj);
                }

                _UnitOfWork.Save();
                TempData["success"] = "Company created successfully";
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
            List<Company> companiesList = _UnitOfWork.Company.GetAll().ToList();
            return Json(new { data = companiesList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var companyToBeDeleted = _UnitOfWork.Company.Get(u => u.Id == id);
            if (companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });

            }
            _UnitOfWork.Company.Remove(companyToBeDeleted);
            _UnitOfWork.Save();


            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion 
    }


}
