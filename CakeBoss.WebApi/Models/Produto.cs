using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeBoss.WebApi.Models
{
	public class Produto
	{
		public Produto(string descricao, double preco, string observacao, double multiplicador)
		{
			this.Descricao = descricao;
			this.Preco = preco;
			this.Observacao = observacao;
			this.Multiplicador = multiplicador;

		}
		public int Id { get; set; }
		[Column(TypeName = "varchar(60)")]
		[Required(ErrorMessage = "Campo Descrição do produto não pode ficar vazio")]
		public string Descricao { get; set; }
		[Column(TypeName = "decimal(8, 2)")]
		public double Preco { get; set; }
		[Column(TypeName = "varchar(MAX)")]
		public string Observacao { get; set; }
		[Column(TypeName = "decimal(8, 2)")]
		public double Multiplicador { get; set; }

		public IEnumerable<ProdutoKit> ProdutosKit { get; set; }
		public IEnumerable<Imagem> Imgens { get; set; }
	}
}