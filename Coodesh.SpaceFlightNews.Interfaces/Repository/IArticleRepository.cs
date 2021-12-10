using Coodesh.SpaceFlightNews.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Interfaces.Repository
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAll();
        Task<DTO.Article> GetById(int id);
        Task Add(Article article);
        Task AddNew(IEnumerable<Article> articles);
        Task Update(int id, Article article);
        Task Delete(int id);

    }
}
