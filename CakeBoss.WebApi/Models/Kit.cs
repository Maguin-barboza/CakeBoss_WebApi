using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CakeBoss.WebApi.Models
{
	public class Kit
	{
		public Kit(string descricao, double desconto, string observacao)
		{
			this.Descricao = descricao;
			this.Desconto = desconto;
			this.Observacao = observacao;

		}

		public int Id { get; set; }
		[Column(TypeName = "varchar(60)")]
		[Required(ErrorMessage = "O campo Descrição do kit não pode ficar vazio")]
		public string Descricao { get; set; }
		[Column(TypeName = "decimal(8, 2)")]
		public double Desconto { get; set; }
		[Column(TypeName = "varchar(MAX)")]
		public string Observacao { get; set; }

		public IEnumerable<ProdutoKit> ProdutosKit { get; set; }
	}
}