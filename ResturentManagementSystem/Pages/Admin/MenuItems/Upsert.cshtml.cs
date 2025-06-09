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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            menuItem = new();
            _webHostEnvironment = webHostEnvironment;
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                menuItem = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == id);
            }
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
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (menuItem.Id == 0)
            {
                //Create
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"Images/MenuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                menuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
                _unitOfWork.MenuItem.Add(menuItem);
                _unitOfWork.Save();
            }
            else { 
                //Edit
                var objFromDb=_unitOfWork.MenuItem.GetFirstOrDefault(x=>x.Id == menuItem.Id);
                if (files.Count>0) 
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"Images/MenuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    //delete old image
                    var oldImagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    menuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
                }
                else
                {
                    menuItem.Image = objFromDb.Image;
                }
                _unitOfWork.MenuItem.Update(menuItem);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
