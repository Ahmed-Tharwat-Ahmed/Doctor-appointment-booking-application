namespace App.Shared.ResponseData
{
    public class PaginationResponse
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalItems { get; private set; }

        public int TotalPages { get; private set; }


        private PaginationResponse(PaginationRequest paginationRequest, int totalItems)
        {
            PageIndex = paginationRequest.PageIndex;
            PageSize = paginationRequest.PageSize;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)paginationRequest.PageSize);
        }

        public static PaginationResponse CreatePagination(PaginationRequest paginationRequest, int totalItems)
        {
            return new PaginationResponse(paginationRequest, totalItems);
        }

    }
}
