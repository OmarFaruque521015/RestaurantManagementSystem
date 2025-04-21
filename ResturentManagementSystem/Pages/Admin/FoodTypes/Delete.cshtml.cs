using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.FoodTypes
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public FoodType foodType { get; set; }
        private readonly ApplicationDBContext _db;

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            foodType = _db.FoodType.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var FDT = _db.FoodType.Find(foodType.Id);
            if (FDT != null)
            {
                _db.FoodType.Remove(FDT);
                await _db.SaveChangesAsync();
                TempData["success"] = "Food Type Deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
