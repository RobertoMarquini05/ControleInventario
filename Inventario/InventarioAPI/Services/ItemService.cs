using InventarioAPI.Models;
using InventarioAPI.Repositories;

namespace InventarioAPI.Services
{
    public class ItemService
    {
        public List<Item> Listar() 
        { 
            return ItemRepository.GetAll(); 
        }

        public Item? ObterPorId(Guid id)
        {
            return ItemRepository.GetById(id);
        }

        public void Criar(Item item)
        {
            ItemRepository.Add(item); 
        }

        public bool Atualizar(Guid id, Item item)
        {
            return ItemRepository.Update(id, item); 
        }

        public bool Deletar(Guid id)
        {
            return ItemRepository.Delete(id);
        }
    }
}
