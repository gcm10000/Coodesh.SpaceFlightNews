using Coodesh.SpaceFlightNews.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationContext _applicationContext;
        //private bool Disposed = false;

        public ArticleRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Add(DTO.Article article)
        {
            _applicationContext.Articles.Add(article);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task AddNew(IEnumerable<DTO.Article> articles)
        {

            foreach (var article in articles)
            {
                var result = await _applicationContext
                                   .Articles
                                   .Where(x => x.IdAPI == article.IdAPI).AnyAsync();
                if (!result)
                {
                    _applicationContext.Articles.Add(article);
                    await _applicationContext.SaveChangesAsync();
                }
            }

        }

        public async Task Delete(int id)
        {
            var article = await _applicationContext.Articles.FindAsync(id);
            _applicationContext.Articles.Remove(article);
            await _applicationContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DTO.Article>> GetAll()
        {
            return await _applicationContext
                         .Articles
                         .Include(x => x.Launches)
                         .Include(x => x.Events)
                         .ToListAsync();
        }

        public async Task<DTO.Article> GetById(int id)
        {
            return await _applicationContext
                         .Articles
                         .Include(x => x.Launches)
                         .Include(x => x.Events)
                         .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, DTO.Article article)
        {
            article.Id = id;
            _applicationContext.Entry(article).State = EntityState.Modified;
            await _applicationContext.SaveChangesAsync();
        }
    }
}
