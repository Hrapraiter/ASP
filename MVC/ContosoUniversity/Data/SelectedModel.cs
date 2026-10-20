using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContosoUniversity.Data
{
    public class SelectedModel
    {
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Options { get; set; }
    }
}
