using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books_sec02revised.Models
{
    public class Cart
    {

        public int CartId { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        [ValidateNever]

        public Book book { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public int Quantity {  get; set; }

    }
}
