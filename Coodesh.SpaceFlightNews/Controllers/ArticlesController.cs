using Coodesh.SpaceFlightNews.Interfaces.Services;
using Coodesh.SpaceFlightNews.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Controllers.Web
{
    [ApiController()]
    [Route("/articles")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await articleService.GetAllAsync();
            return Ok(articles);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var article = await articleService.GetByIdAsync(id);
            return Ok(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticleAsync([FromBody] Article article)
        {
            await articleService.AddAsync(article);
            
            return Ok(new { message = "Artigo adicionado com sucesso."});
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateById([FromBody] Article article, int id)
        {
            await articleService.UpdateAsync(id, article);
            return Ok(new { message = "Artigo atualizado com sucesso." });
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveById(int id)
        {
            await articleService.DeleteAsync(id);

            return Ok(new { message = "Artigo removido com sucesso." });
        }

    }
}
