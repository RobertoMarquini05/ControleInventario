namespace InventarioAPI.Models
{
    public class Movimentacao
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public string Tipo { get; set; } = "entrada"; // ou "saida"
        public int Quantidade { get; set; }
        public DateTime Data { get; set; }
        public string? Observacao { get; set; }

        public Movimentacao(Guid itemId, string tipo, int quantidade, string? obs)
        {
            Id = Guid.NewGuid();
            ItemId = itemId;
            Tipo = tipo;
            Quantidade = quantidade;
            Data = DateTime.UtcNow;
            Observacao = obs;
        }
    }
}
