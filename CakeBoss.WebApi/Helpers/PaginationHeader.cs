namespace CakeBoss.WebApi.Helpers
{
	public class PaginationHeader
	{
		public int CurrentPage { get; set; }
		public int TotalItems { get; set; }
		public int TotalItemsInPage { get; set; }
		public int TotalPages { get; set; }
		
        public PaginationHeader(int currentPage, int totalItems, int totalItemsInPage, int totalPages)
		{
			this.CurrentPage = currentPage;
			this.TotalItems = totalItems;
			this.TotalItemsInPage = totalItemsInPage;
			this.TotalPages = totalPages;

		}
	}
}