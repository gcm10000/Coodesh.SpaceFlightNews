using Coodesh.SpaceFlightNews.Controllers.Web;
using Coodesh.SpaceFlightNews.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Coodesh.SpaceFlightNews.Tests
{
    public class UnitTestArticle
    {
        readonly Mock<IArticleService> _mockArticleService = new Mock<IArticleService>();

        [Fact]
        public async void AddArticleTest()
        {
            _mockArticleService.Setup(x => x.AddAsync(It.IsAny<ViewModel.Article>()).Result).Returns(true);
            ArticlesController articlesController = new ArticlesController(_mockArticleService.Object);
            var result = await articlesController.AddArticleAsync(It.IsAny<ViewModel.Article>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void UpdateArticleTest()
        {
            _mockArticleService.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<ViewModel.Article>()).Result).Returns(true);
            ArticlesController articlesController = new ArticlesController(_mockArticleService.Object);

            var result = await articlesController.UpdateById(It.IsAny<ViewModel.Article>(), It.IsAny<int>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async void DeleteArticleTest()
        {
            _mockArticleService.Setup(x => x.DeleteAsync(It.IsAny<int>()).Result).Returns(true);
            ArticlesController ArticlesController = new ArticlesController(_mockArticleService.Object);

            var result = await ArticlesController.RemoveById(It.IsAny<int>());

            var okResult = result as OkObjectResult;

            // assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

    }
}
