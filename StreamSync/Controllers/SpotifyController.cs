using FuzzyString;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StreamSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {

        private readonly ILogger<SpotifyController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string spotifyApiUrl = "http://localhost:8082/integracao/spotify/";

        public SpotifyController(ILogger<SpotifyController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("/Teste")]
        public IActionResult Teste()
        {
            return Ok("teste ok");
        }

        [HttpGet("Procurar/{consulta}/{tipo}")]
        public async Task<IActionResult> SpotifySearch(string consulta, string tipo)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = spotifyApiUrl + "procurar?q=" + consulta + "&type=" + tipo;

            // Faça a requisição HTTP para a API da Spotify
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        [HttpGet("Acompanhar/{id}")]
        public async Task<IActionResult> SpotifyTrilha(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = spotifyApiUrl + "Acompanhar/" + id;

            // Faça a requisição HTTP para a API da Spotify
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        [HttpGet("Album/{id}/{mercado}")]
        public async Task<IActionResult> SpotifyAlbum(string id, string mercado)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = spotifyApiUrl + "album/" + id + "&market=" + mercado;

            // Faça a requisição HTTP para a API da Spotify
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        [HttpGet("Lista_de_musica/{id}/{mercado}")]
        public async Task<IActionResult> SpotifyLista_de_musica(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = spotifyApiUrl + "Lista_de_musica/" + id;

            // Faça a requisição HTTP para a API da Spotify
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        static string EncontrarStringMaisSemelhante(string stringOriginal, List<string> stringsComparacao)
        {
            string maisSemelhante = null;
            int menorDistancia = int.MaxValue;

            foreach (var str in stringsComparacao)
            {
                int distancia = str.LevenshteinDistance(stringOriginal);

                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    maisSemelhante = str;
                }
            }

            return maisSemelhante;
        }

    }
}
