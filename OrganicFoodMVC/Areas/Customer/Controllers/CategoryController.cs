using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrganicFoodMVC.DataAccess.Repository.IRepository;
using OrganicFoodMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganicFoodMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // Search product with category and product name
        public IActionResult Index(int id, string productName)
        {
            IEnumerable<Product> products;
            if((productName == "" || productName == null) && id == 0)
            {
                products = _unitOfWork.Product.GetAll(includeProperties: "Category,Brand,Unit");
            }    
            else if (productName == "" || productName == null || id < 0)
            {
                products = _unitOfWork.Product.GetAll(p => p.CategoryId == id || p.CategoryId == id, includeProperties: "Category,Brand,Unit");
            }
            else
            {
                products = _unitOfWork.Product.GetAll(p => p.CategoryId == id && p.Name.Contains(productName), includeProperties: "Category,Brand,Unit");
            }

            return View(products);
        }
    }
}
