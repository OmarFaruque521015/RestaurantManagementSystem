using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        public ApplicationDBContext _db;
        public IEnumerable<FoodType> FoodTypes { get; set; }
        public IndexModel(ApplicationDBContext db)
        {
              _db = db;
        }
        public void OnGet()
        {
            FoodTypes = _db.FoodType;
        }
    }
}
