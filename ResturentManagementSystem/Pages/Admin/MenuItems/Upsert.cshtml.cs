using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.MenuItems
{
    public class UpsertModel : PageModel
    {
        [BindProperty]
        public MenuItem menuItem { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            menuItem = new();
        }
        public void OnGet()
        {
            CategoryList = _unitOfWork.Category.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MenuItem.Add(menuItem);
                _unitOfWork.Save();
                TempData["success"] = "Menu Item created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
