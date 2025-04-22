using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.FoodTypes
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public FoodType foodType { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Add(foodType);
                _unitOfWork.Save();
                TempData["success"] = "Food Type created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
