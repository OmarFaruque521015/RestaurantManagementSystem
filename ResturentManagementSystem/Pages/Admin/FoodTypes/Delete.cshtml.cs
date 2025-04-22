using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.FoodTypes
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public FoodType foodType { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            foodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var FDT = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == foodType.Id);
            if (FDT != null)
            {
                _unitOfWork.FoodType.Remove(FDT);
                _unitOfWork.Save();
                TempData["success"] = "Food Type Deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
