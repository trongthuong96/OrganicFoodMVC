using Microsoft.AspNetCore.Mvc;
using OrganicFoodMVC.DataAccess.Repository.IRepository;
using OrganicFoodMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFoodMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Brand brand = new Brand();
            if(id == null)
            {
                // this is for create
                return View(brand);
            }

            //this is for edit
            brand = _unitOfWork.Brand.Get(id.GetValueOrDefault());
            if(brand == null)
            {
                return NotFound();
            }
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Brand brand)
        {
            if (ModelState.IsValid)
            {
                if(brand.Id == 0)
                {
                    _unitOfWork.Brand.Add(brand);
                }
                else
                {
                    _unitOfWork.Brand.Update(brand);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Brand.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Brand.Get(id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Xóa thất bại!" });
            }
            _unitOfWork.Brand.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công!" });
        }

        #endregion
    }
}
