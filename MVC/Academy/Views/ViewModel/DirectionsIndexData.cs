using Academy.Models;

namespace Academy.Views.ViewModel
{
    public class DirectionsIndexData
    {
        public IEnumerable<Direction>? Directions { get; set; }
        public IEnumerable<Group>? Groups { get; set; }
        public IEnumerable<Student>? Students { get; set; }
    }
}
