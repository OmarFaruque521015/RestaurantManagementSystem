using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public FoodType foodType { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            foodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Update(foodType);
                _unitOfWork.Save();
                TempData["success"] = "Food Type Updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
