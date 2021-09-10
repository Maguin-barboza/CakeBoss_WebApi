namespace CakeBoss.WebApi.DTOs
{
    public class ProdutoKitDTO
    {
        public int KitId { get; set; }
        public int ProdutoId { get; set; }
        public ProdutoDTO Produto { get; set; }
        public double Quantidade { get; set; }
        public double QuantidadeReal { get => this.Quantidade * Produto.Multiplicador; }
    }
}