using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResturentManagementSystem.Data;
using ResturentManagementSystem.Model;

namespace ResturentManagementSystem.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly ApplicationDBContext _db;

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            var Cate = _db.Category.Find(Category.Id);
            if (Cate != null)
            {
                _db.Category.Remove(Cate);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
