﻿using System.ComponentModel.DataAnnotations;

namespace RestaurantManagementSystem.Models
{
    public class FoodType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
