namespace Infrastructure.DTOs
{
    

    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StatusEnum Status { get; set; }
        public string SortBy { get; set; }
        public string Search { get; set; }
        public SortOrderEnum SortOrder { get; set; }

        public PaginationRequest()
        {
            PageNumber = 1;
            PageSize = 10;
            Status = StatusEnum.Active;
            SortBy = "UpdatedAt";
            Search = "";
            SortOrder = SortOrderEnum.DESC;
        }

        public PaginationRequest(int pageNumber, int pageSize, StatusEnum status = StatusEnum.Active, string search = "", string sortBy = "UpdatedAt", SortOrderEnum sortOrder = SortOrderEnum.DESC)
        {
            PageNumber = Math.Max(1, pageNumber);
            PageSize = Math.Min(100, Math.Max(1, pageSize));
            Status = status;
            SortBy = sortBy;
            Search = search;
            SortOrder = sortOrder;
        }
    }
}
