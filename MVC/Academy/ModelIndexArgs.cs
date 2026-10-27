namespace Academy
{
    public class ModelIndexArgs
    {
        public string orderByName;
        public string orderByDate;
        public string searchString;
        public int    pageIndex;
        public int    pageSize;
        public ModelIndexArgs(string orderByName = "", string orderByDate = "", string searchString = "", int pageIndex = 0, int pageSize = 5)
        {
            this.orderByName = orderByName;
            this.orderByDate = orderByDate;
            this.searchString = searchString;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }
    }
}
