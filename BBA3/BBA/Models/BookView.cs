using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BBA.Models
{
    public class BookView
    {
        [Key]
        public int BookID { get; set; }

        [Display(Name = "Cover Image")]
        public IFormFile? BookImage { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Author { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Publisher { get; set; }

        [Required]
        public string? Genre { get; set; }

        public string? Description { get; set; }
    }
}
