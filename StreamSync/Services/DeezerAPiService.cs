using StreamSync.Services.Interfaces;
using System.Net;

namespace StreamSync.Services
{
    public class DeezerApiService : IDeezerApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly static string ApiUrl = "http://plugin-deezer:8082/integracao/deezer/";

        public DeezerApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Album(Int64 id, string mercado)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = ApiUrl + "album/" + id + "&market=" + mercado;

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            return conteudo;
        }

        public async Task<string> Lista_de_musica(Int64 id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = ApiUrl + "Lista_de_musica/" + id;

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            return conteudo;
        }

        public async Task<string> Procurar(string consulta, string tipo)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = ApiUrl + "procurar?q=" + tipo + ":%22" + Uri.EscapeDataString(consulta) + "%22";

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            DeezerSearchResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<DeezerSearchResult>(conteudo);

            return conteudo;
        }

        public async Task<string> Trilha(Int64 id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = ApiUrl + "Acompanhar/" + id;

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            return conteudo;
        }

        public async Task<string> Link(string request)
        {
            var httpClient = _httpClientFactory.CreateClient();

            request = WebUtility.UrlDecode(request);

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            var a = response.RequestMessage.RequestUri.LocalPath;

            return conteudo;
        }

    }
}
