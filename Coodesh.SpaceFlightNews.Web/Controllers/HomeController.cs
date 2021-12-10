using Coodesh.SpaceFlightNews.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Coodesh.SpaceFlightNews.Controllers.Web
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok("Back-end Challenge 2021 🏅 - Space Flight News");
        }
    }
}
