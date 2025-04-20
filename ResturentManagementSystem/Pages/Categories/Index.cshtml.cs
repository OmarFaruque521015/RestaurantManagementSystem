using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResturentManagementSystem.Data;
using ResturentManagementSystem.Model;

namespace ResturentManagementSystem.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public ApplicationDBContext _db;
        public IEnumerable<Category> Categories { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
              _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
