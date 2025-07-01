namespace InventarioAPI.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Categoria(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
    }
}
