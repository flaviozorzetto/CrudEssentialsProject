﻿using System.ComponentModel.DataAnnotations;

namespace CrudEssentialsProject.Models.Dto
{
    public class ProductRequestDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }
    }
}
