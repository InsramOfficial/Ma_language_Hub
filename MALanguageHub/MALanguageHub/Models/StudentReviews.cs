﻿using System.ComponentModel.DataAnnotations;

namespace MALanguageHub.Models
{
    public class StudentReviews
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [Display(Name = "Name")]
        [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Designation is required.")]
        [Display(Name = "Designation")]
        [MaxLength(200, ErrorMessage = "Designation cannot exceed 200 characters.")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Review is required.")]
        [Display(Name = "Review")]
        [MaxLength(1000, ErrorMessage = "Review cannot exceed 1000 characters.")]
        public string Review { get; set; }
    }
}
