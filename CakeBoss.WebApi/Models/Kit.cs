using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CakeBoss.WebApi.Models
{
	public class Kit
	{
		public int Id { get; set; }
		[Column(TypeName = "varchar(60)")]
		[Required(ErrorMessage = "O campo Descrição do kit não pode ficar vazio")]
		public string Descricao { get; set; }
		[Column(TypeName = "decimal(8, 2)")]
		public double Desconto { get; set; }
		
		public double Preco
		{ 
			get
			{
				double descontoRateio = Desconto / Produtos.Sum(p => p.Quantidade);
				double PrecoTotalKit = Produtos.Sum(p => (p.Preco * p.Quantidade) - descontoRateio);
				return PrecoTotalKit;
			}
		}
		[Column(TypeName = "varchar(MAX)")]
		public string Observacao { get; set; }
		
		public IEnumerable<Produto> Produtos { get; set; }
	}
}