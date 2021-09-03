using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakeBoss.WebApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        [Required(ErrorMessage = "Campo Descrição do produto não pode ficar vazio")]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public double Preco { get; set; }
        [Column(TypeName = "varchar(MAX)")]
        public string Observacao { get; set; }
        public int Quantidade { get; set; }
        public int? KitId { get; set; } = null;
        public Kit Kit { get; set; }
        
        public IEnumerable<Imagem> Imgens { get; set; }
    }
}