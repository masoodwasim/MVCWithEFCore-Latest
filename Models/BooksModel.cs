using SampleWebWidMVC.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWebWidMVC.Models
{
    public class BooksModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; } 
        public string Publisher { get; set; }

        [Required]
        [CategoryValidate(Allowed = new string[] { "IT-Infrastructure", "IT-Cloud", "IT-Programming","Marketing" }, ErrorMessage = "Book Category are invalid")]
        public string Category { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
