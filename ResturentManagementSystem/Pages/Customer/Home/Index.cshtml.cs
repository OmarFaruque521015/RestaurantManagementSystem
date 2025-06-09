using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Pages.Admin.Customer.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MenuItem> MenuItemList { get; set; }
        public IEnumerable<Category> CategoryList {  get; set; }
        public void OnGet()
        {
            MenuItemList = _unitOfWork.MenuItem.GetAll(includingProperties: "Category,FoodType");
            CategoryList = _unitOfWork.Category.GetAll(orderby: u=>u.OrderBy(c=>c.DisplayOrder));
        }
    }
}
