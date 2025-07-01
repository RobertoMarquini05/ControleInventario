using InventarioAPI.Models;
using InventarioAPI.Repositories;

namespace InventarioAPI.Services
{
    public class MovimentacaoService
    {
        public List<Movimentacao> ListarTodas()
        {
            return MovimentacaoRepository.GetAll();
        }
        public void Registrar(Movimentacao mov)
        {
            MovimentacaoRepository.Add(mov);

            var item = ItemRepository.GetById(mov.ItemId);
            if (item == null) return;

            if (mov.Tipo == "entrada")
                item.Quantidade += mov.Quantidade;
            else if (mov.Tipo == "saida")
                item.Quantidade -= mov.Quantidade;

            ItemRepository.Update(item.Id, item);
        }

        public List<Movimentacao> PorItem(Guid itemId)
        {
            return MovimentacaoRepository.GetByItemId(itemId);
        }

        public List<Movimentacao> PorTipo(string tipo)
        {
            return MovimentacaoRepository.GetByTipo(tipo); 
        }
    }
}
