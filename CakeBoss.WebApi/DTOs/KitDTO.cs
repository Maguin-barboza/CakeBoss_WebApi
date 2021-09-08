using System.Collections.Generic;
using System.Linq;

namespace CakeBoss.WebApi.DTOs
{
	public class KitDTO
	{
		public int Id { get; set; }
		public string Descricao { get; set; }
        public double Desconto { get; set; }
		public double Preco
		{
    		get
			{
                //double desconcoRateio = Desconto / ProdutosKitsDto.Sum(p => p.)
                return 0;
			}
		}

        public IEnumerable<ProdutosKitDTO> ProdutosKitsDto { get; set; }
	}
}