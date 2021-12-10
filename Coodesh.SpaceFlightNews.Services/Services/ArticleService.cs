using Coodesh.SpaceFlightNews;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Coodesh.SpaceFlightNews.Interfaces.Services;
using Coodesh.SpaceFlightNews.Interfaces.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Coodesh.SpaceFlightNews.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ILogger<ArticleService> _logger;
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public ArticleService(ILogger<ArticleService> logger, IMapper mapper, IArticleRepository articleRepository)
        {
            _logger = logger;
            this._mapper = mapper;
            this._articleRepository = articleRepository;
        }


        public async Task<bool> AddAsync(ViewModel.Article article)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Start ArticleService Add");
                var articleDTO = _mapper.Map<ViewModel.Article, DTO.Article>(article);
                await _articleRepository.Add(articleDTO);
            }
            catch
            {
                _logger.Log(LogLevel.Error, "Finish ArticleService Add");
                return false;
            }
            _logger.Log(LogLevel.Information, "Finish ArticleService Add");
            return true;

        }

        public async Task<bool> AddNew(IEnumerable<ViewModel.Article> articles)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Start ArticleService AddNew");

                var articlesDTO = _mapper.Map<IEnumerable<ViewModel.Article>, IEnumerable<DTO.Article>>(articles);
                await _articleRepository.AddNew(articlesDTO);
            }
            catch
            {

                _logger.Log(LogLevel.Error, "Finish ArticleService AddNew");
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Start ArticleService Delete");
                await _articleRepository.Delete(id);
            }
            catch
            {
                _logger.Log(LogLevel.Error, "Finish ArticleService Delete");
                return false;
            }
            _logger.Log(LogLevel.Information, "Finish ArticleService Delete");
            return true;
        }

        public async Task<IEnumerable<ViewModel.Article>> GetAllAsync()
        {
            _logger.Log(LogLevel.Information, "Start ArticleService GetAll");

            IEnumerable<DTO.Article> articles = await _articleRepository.GetAll();

            var articleViewModel = _mapper.Map<IEnumerable<DTO.Article>, IEnumerable<ViewModel.Article>>(articles);
           
            _logger.Log(LogLevel.Information, "Finish ArticleService GetAll");
            return articleViewModel;
        }

        public async Task<ViewModel.Article> GetByIdAsync(int id)
        {
            _logger.Log(LogLevel.Information, "Start ArticleService GetById");

            DTO.Article article = await _articleRepository.GetById(id);
            var articleViewModel = _mapper.Map<DTO.Article, ViewModel.Article>(article);

            _logger.Log(LogLevel.Information, "Finish ArticleService GetById");
            return articleViewModel;
        }

        public async Task<bool> UpdateAsync(int id, ViewModel.Article article)
        {
            try
            {
                _logger.Log(LogLevel.Information, "Start ArticleService Update");

                var articleDTO = _mapper.Map<ViewModel.Article, DTO.Article>(article);

                await _articleRepository.Update(id, articleDTO);

                _logger.Log(LogLevel.Information, "Finish ArticleService Update");

            }
            catch
            {
                _logger.Log(LogLevel.Error, "Finish ArticleService Delete");

                return false;
            }
            return true;
        }
    }
}
