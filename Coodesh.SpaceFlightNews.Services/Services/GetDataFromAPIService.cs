using Coodesh.SpaceFlightNews.DTO;
using Coodesh.SpaceFlightNews.Interfaces.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Coodesh.SpaceFlightNews.Services
{
    public class GetDataFromAPIService : IDataFromAPIService
    {
        private readonly HttpClient _client;

        public GetDataFromAPIService()
        {
            this._client = new HttpClient();
        }

        public async Task<ResponseHttp<T>> GetRequestAsync<T>(string requestUri)
        {
            var responseMessage = await _client.GetAsync(requestUri);
            var result = await responseMessage.Content.ReadAsStringAsync();

            return new ResponseHttp<T>() { IsSuccessStatusCode = responseMessage.IsSuccessStatusCode, Item = JsonSerializer.Deserialize<T>(result) };
        }

        public async Task<ResponseHttp<T>> AlertError<T>(string apiToken, string chatId, string text)
        {
            string requestUri = $"https://api.telegram.org/bot{apiToken}/sendMessage?chat_id={chatId}&text={text}";
            var responseMessage = await _client.GetAsync(requestUri);
            var result = await responseMessage.Content.ReadAsStringAsync();

            return new ResponseHttp<T>() { IsSuccessStatusCode = responseMessage.IsSuccessStatusCode, Item = JsonSerializer.Deserialize<T>(result) };
        }
    }
}
