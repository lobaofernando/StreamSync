using StreamSync.Services.Interfaces;

namespace StreamSync.Services
{
    public class SpotifyApiService : ISpotifyApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly static string ApiUrl = "http://plugin-spotify:8081/integracao/spotify/";

        public SpotifyApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Album(string id, string mercado)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = ApiUrl + "album/" + id + "&market=" + mercado;

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            return conteudo;
        }

        public async Task<string> Lista_de_musica(string id)
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
            var request = ApiUrl + "procurar?q=" + consulta + "&type=" + tipo;

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            SpotifySearchResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<SpotifySearchResult>(conteudo);

            return conteudo;
        }

        public async Task<string> Trilha(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var request = ApiUrl + "Acompanhar/" + id;

            HttpResponseMessage response = await httpClient.GetAsync(request);

            string conteudo = await response.Content.ReadAsStringAsync();

            return conteudo;
        }

    }
}
