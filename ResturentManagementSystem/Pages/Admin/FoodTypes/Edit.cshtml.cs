using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.FoodTypes
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public FoodType foodType { get; set; }
        private readonly ApplicationDBContext _db;

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            foodType = _db.FoodType.Find(id);
        }

        public async Task<IActionResult> OnPost()
        { 
            if (ModelState.IsValid)
            {
                 _db.FoodType.Update(foodType);
                await _db.SaveChangesAsync();
                TempData["success"] = "Food Type Updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
