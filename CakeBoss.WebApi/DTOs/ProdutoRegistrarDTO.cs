namespace CakeBoss.WebApi.DTOs
{
    public class ProdutoRegistrarDTO
    {
        public int Id { get; set; }
		public string Descricao { get; set; }
		public double Preco { get; set; }
		public string Observacao { get; set; }
		public double Multiplicador { get; set; }
    }
}