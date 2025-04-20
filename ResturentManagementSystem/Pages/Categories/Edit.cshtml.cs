using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResturentManagementSystem.Data;
using ResturentManagementSystem.Model;

namespace ResturentManagementSystem.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDBContext _db;

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (Category.Name == Category.DisplayOrder.ToString()) {
                ModelState.AddModelError(Category.Name, "The DisplayOrder can not exectly match the Name.");
            }
            if (ModelState.IsValid)
            {
                 _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
