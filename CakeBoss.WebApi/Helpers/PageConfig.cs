namespace CakeBoss.WebApi.Helpers
{
	public class PageConfig
	{
		public int CurrentPage { get; set; } = 1;
		public int PageSize { get; set; } = 5;

		public int? ByIdProduto { get; set; } = null;
		public string byDescProd { get; set; } = string.Empty;
		public double PrMin { get; set; } = 0;
		public double? PrMax { get; set; } = 0;

		public bool OrderByIdProduto { get; set; } = false;
		public bool OrderByDesc { get; set; } = false;
		public bool OrderByPreco { get; set; } = false;
	}
}