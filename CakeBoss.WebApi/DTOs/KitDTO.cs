using System.Collections.Generic;
using System.Linq;

namespace CakeBoss.WebApi.DTOs
{
	public class KitDTO
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
        public double Desconto { get; set; }
		public double ValorTotal { get; set; }

        public IEnumerable<ProdutoKitDTO> ProdutosKit { get; set; }
	}
}