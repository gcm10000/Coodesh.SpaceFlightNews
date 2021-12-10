using Coodesh.SpaceFlightNews.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Interfaces.Services
{
    public interface IArticleService
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> GetByIdAsync(int id);
        Task<bool> AddAsync(Article article);
        Task<bool> AddNew(IEnumerable<Article> articles);
        Task<bool> UpdateAsync(int id, Article article);
        Task<bool> DeleteAsync(int id);

    }
}
