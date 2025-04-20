using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name="Display Order")]
        [Range(0,100,ErrorMessage ="Display order must be in range of 1-1000!!!")]
        public int DisplayOrder { get; set; }
    }
}
