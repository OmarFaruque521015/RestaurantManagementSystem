using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        public IUnitOfWork _unitOfWork;
        public IEnumerable<MenuItem> MenuItems { get; set; }
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            MenuItems = _unitOfWork.MenuItem.GetAll();
        }
    }
}
