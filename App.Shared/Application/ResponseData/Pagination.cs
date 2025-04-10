namespace App.Shared.ResponseData
{
    public class Pagination
    {
        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int TotalItems { get; private set; }

        public int TotalPages { get; private set; }


        private Pagination(int currentPage, int pageSize, int totalItems)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }

        public static Pagination CreatePagination(int currentPage, int pageSize, int totalItems)
        {
            return new Pagination(currentPage, pageSize, totalItems);
        }

    }
}
