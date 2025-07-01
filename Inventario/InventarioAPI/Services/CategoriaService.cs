using InventarioAPI.Models;
using InventarioAPI.Repositories;

namespace InventarioAPI.Services
{
    public class CategoriaService
    {
        public List<Categoria> Listar() 
        {
            return CategoriaRepository.GetAll();
        }
        public Categoria? ObterPorId(Guid id)
        {
            return CategoriaRepository.GetById(id);
        }

        public void Criar(Categoria categoria)
        {
            CategoriaRepository.Add(categoria);
        }

        public bool Atualizar(Guid id, Categoria categoria)
        {
            return CategoriaRepository.Update(id, categoria);
        }

        public bool Deletar(Guid id)
        {
            return CategoriaRepository.Delete(id);
        }
    }
}
