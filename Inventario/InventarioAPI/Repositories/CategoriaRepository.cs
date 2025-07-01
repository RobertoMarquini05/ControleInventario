using InventarioAPI.Models;
using System.Text.Json;

namespace InventarioAPI.Repositories
{
    public static class CategoriaRepository
    {
        private static readonly string filePath = "categorias.json";

        public static List<Categoria> GetAll()
        {
            if (!File.Exists(filePath)) return new();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Categoria>>(json) ?? new();
        }

        public static Categoria? GetById(Guid id) => GetAll().FirstOrDefault(c => c.Id == id);

        public static void SaveAll(List<Categoria> categorias)
        {
            var json = JsonSerializer.Serialize(categorias, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static void Add(Categoria categoria)
        {
            var categorias = GetAll();
            categorias.Add(categoria);
            SaveAll(categorias);
        }

        public static bool Update(Guid id, Categoria atualizada)
        {
            var categorias = GetAll();
            var index = categorias.FindIndex(c => c.Id == id);
            if (index == -1) return false;

            atualizada.Id = id;
            categorias[index] = atualizada;
            SaveAll(categorias);
            return true;
        }

        public static bool Delete(Guid id)
        {
            var categorias = GetAll();
            var cat = categorias.FirstOrDefault(c => c.Id == id);
            if (cat == null) return false;

            categorias.Remove(cat);
            SaveAll(categorias);
            return true;
        }
    }
}
