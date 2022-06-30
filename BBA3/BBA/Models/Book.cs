using System.ComponentModel.DataAnnotations;

namespace BBA.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }

        [Display(Name = "Cover Image")]
        public string? BookImage { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [Required]
        public string? Publisher { get; set; }

        [Required]
        public string? Genre { get; set; }

        public string? Description { get; set; }
    }
}
