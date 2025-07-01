using InventarioAPI.Models;
using System.Text.Json;

namespace InventarioAPI.Repositories
{
    public static class MovimentacaoRepository
    {
        private static readonly string filePath = "movimentacoes.json";

        public static List<Movimentacao> GetAll()
        {
            if (!File.Exists(filePath)) return new();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Movimentacao>>(json) ?? new();
        }

        public static void SaveAll(List<Movimentacao> lista)
        {
            var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static void Add(Movimentacao mov)
        {
            var movimentacoes = GetAll();
            movimentacoes.Add(mov);
            SaveAll(movimentacoes);
        }

        public static List<Movimentacao> GetByItemId(Guid itemId)
        {
            return GetAll().Where(m => m.ItemId == itemId).ToList();
        }

        public static List<Movimentacao> GetByTipo(string tipo)
        {
            return GetAll().Where(m => m.Tipo.Equals(tipo, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
