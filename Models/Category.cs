using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books_sec02revised.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [DisplayName("Category Name: ")]
        [Required(ErrorMessage ="The name for the category must be provided")]
        public string Name { get; set; }
        [DisplayName("Category Description: ")]
        [Required(ErrorMessage = "The Description for the category must be provided")]

        public string Description { get; set; }

    }
}


