namespace Academy
{
    public static class MarkupHtmlHelper
    {
        
        //Returns:
        // first previus , two next. Function print strings "" or "disabled" 
        // if's for writed strings with PaginatedList this .HasPreviusPage and .HasNextPage
        //Used:
        //  (string previusDesabled ,string nextDisabled) = InnitPrevAndNextDisabled(list);
        public static (string , string) InnitPrevAndNextDisabled<T>(PaginatedList<T> list)
        {
            const string disabled = "disabled";
            return
            (
                list.HasPreviusPage ? "" : disabled ,
                list.HasNextPage? "" : disabled
            );
        }
        public static char DisplayOrder(string orderStr) => orderStr == "asc" ? '^' : orderStr == "desc" ? 'v' : ' ';
        public static string OrderInnit(string controllerOrderStr) => controllerOrderStr == "" ? "asc" : controllerOrderStr == "asc" ? "desc" : "";
    }
}
