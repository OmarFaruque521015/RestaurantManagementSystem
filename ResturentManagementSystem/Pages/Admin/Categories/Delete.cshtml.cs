using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using RestaurantManagementSystem.Models;

namespace ResturentManagementSystem.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Category Category { get; set; }
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var Cate = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
            if (Cate != null)
            {
                _unitOfWork.Category.Remove(Cate);
                 _unitOfWork.Save();
                TempData["success"] = "Category Deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
