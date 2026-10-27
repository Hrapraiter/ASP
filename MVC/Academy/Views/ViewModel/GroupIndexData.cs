using Academy.Models;
namespace Academy.Views.ViewModel
{
    public class GroupIndexData
    {
        public PaginatedList<Group>? Groups { get; set; }
        public PaginatedList<Student>? Students { get; set; }
    }
}
