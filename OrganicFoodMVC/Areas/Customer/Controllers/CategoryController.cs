using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OrganicFoodMVC.DataAccess.Repository.IRepository;
using OrganicFoodMVC.Models;
using OrganicFoodMVC.Utility;
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
        public IActionResult Index(int categoryid, string productName)
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category,Brand,Unit");
            string romoveHintProductName;
            if (productName != "" && productName != null)
            {
                romoveHintProductName = SD.RemoveVietnameseTone(productName);
            }
            else
            {
                romoveHintProductName = productName;
            }
           
            if((productName == "" || productName == null) && categoryid == 0)
            { }    
            else if (productName == "" || productName == null || categoryid == 0)
            {
                if(productName != "" && productName != null)
                {
                    products = products.Where(p => SD.RemoveVietnameseTone(p.Name).Contains(romoveHintProductName));
                }
                else
                {
                    products = products.Where(p => p.CategoryId == categoryid);
                }
                
            }
            else if((productName != "" && productName != null) && categoryid > 0)
            {
                products = products.Where(p => p.CategoryId == categoryid && SD.RemoveVietnameseTone(p.Name).Contains(romoveHintProductName));
            }

            return View(products);
        }
    }
}
