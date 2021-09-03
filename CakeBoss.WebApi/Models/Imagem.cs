using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeBoss.WebApi.Models
{
	public class Imagem
	{
		public int Id { get; set; }
		public int ProdutoId { get; set; }
		public Produto Produto { get; set; }

		[Column(TypeName = "varchar(200)")]
		[Required(ErrorMessage = "Campo Caminho da imagem não pode ficar vazio")]
		public string Caminho { get; set; }

		[Column(TypeName = "varchar(500)")]
		[Required(ErrorMessage = "Campo Descrição da imagem não pode ficar vazio")]
		public string Descricao { get; set; }
		public int OrdemVisualizacao { get; set; }
	}
}