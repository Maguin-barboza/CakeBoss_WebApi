using System.ComponentModel.DataAnnotations.Schema;

namespace CakeBoss.WebApi.Models
{
	public class ProdutoKit
	{
        public ProdutoKit() { }
		
        public ProdutoKit(int kitId, int produtoId, double quantidade)
		{
			this.KitId = kitId;
			this.ProdutoId = produtoId;
			this.Quantidade = quantidade;
		}
		public int KitId { get; set; }
		public Kit Kit { get; set; }
		public int ProdutoId { get; set; }
		public Produto Produto { get; set; }
		[Column(TypeName = "decimal(8, 2)")]
		public double Quantidade { get; set; }
	}
}