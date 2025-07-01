using InventarioAPI.Models;
using System.Text.Json;

namespace InventarioAPI.Repositories
{
    public static class ItemRepository
    {
        private static readonly string filePath = "itens.json";

        public static List<Item> GetAll()
        {
            if (!File.Exists(filePath)) return new();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Item>>(json) ?? new();
        }

        public static Item? GetById(Guid id) => GetAll().FirstOrDefault(i => i.Id == id);

        public static void SaveAll(List<Item> itens)
        {
            var json = JsonSerializer.Serialize(itens, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static void Add(Item item)
        {
            var itens = GetAll();
            itens.Add(item);
            SaveAll(itens);
        }

        public static bool Update(Guid id, Item atualizado)
        {
            var itens = GetAll();
            var index = itens.FindIndex(i => i.Id == id);
            if (index == -1) return false;

            atualizado.Id = id;
            itens[index] = atualizado;
            SaveAll(itens);
            return true;
        }

        public static bool Delete(Guid id)
        {
            var itens = GetAll();
            var item = itens.FirstOrDefault(i => i.Id == id);
            if (item == null) return false;

            itens.Remove(item);
            SaveAll(itens);
            return true;
        }
    }
}
