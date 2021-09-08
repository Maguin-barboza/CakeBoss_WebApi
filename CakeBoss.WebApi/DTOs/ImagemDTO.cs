namespace CakeBoss.WebApi.DTOs
{
    public class ImagemDTO
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public string Caminho { get; set; }
        public string Descricao { get; set; }
        public int OrdemVisualizacao { get; set; }
    }
}