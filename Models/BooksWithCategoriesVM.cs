using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Books_sec02revised.Models
{
    public class BooksWithCategoriesVM
    {
        public Book Book { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ListOfCategories { get; set; }
        
    }
}
