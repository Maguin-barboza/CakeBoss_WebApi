using System.Collections.Generic;

namespace CakeBoss.WebApi.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Observacao { get; set; }
        public IEnumerable<ImagemDTO> Imagens { get; set; }
    }
}