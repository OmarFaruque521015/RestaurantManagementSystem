using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Pages.Admin.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MenuItem MenuItem { get; set; }
        [Range(1,100,ErrorMessage ="Please select a count between 1 and 100")]
        public int Count {  get; set; }
        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x=>x.Id==id,includingProperties:"Category,FoodType");
        }
    }
}
