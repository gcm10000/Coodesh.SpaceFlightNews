using Coodesh.SpaceFlightNews.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Interfaces.Services
{
    public interface IDataFromAPIService
    {
        Task<ResponseHttp<T>> GetRequestAsync<T>(string requestUri);
        Task<ResponseHttp<T>> AlertError<T>(string apiToken, string chatId, string text);
    }
}
