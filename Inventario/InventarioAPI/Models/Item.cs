namespace InventarioAPI.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public Item(string nome, string categoria, int quantidade, decimal preco)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Categoria = categoria;
            Quantidade = quantidade;
            Preco = preco;
        }
    }
}
