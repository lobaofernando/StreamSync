using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeezerController : ControllerBase
    {

        private readonly ILogger<DeezerController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public DeezerController(ILogger<DeezerController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("/Teste")]
        public IActionResult Teste()
        {
            return Ok("teste ok");
        }

        [HttpGet("DeezerSearch/{query}")]
        public async Task<IActionResult> DeezerSearch(string query)
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Construa a URL do endpoint search da Deezer com o parâmetro de consulta 'query'
            //var deezerApiUrl = $"https://api.deezer.com/search?q={query}";
            var deezerApiUrl = $"http://localhost:8081/procurar?q={query}";

            // Faça a requisição HTTP para a API da Deezer
            var response = await httpClient.GetStringAsync(deezerApiUrl);

            // Deserialize a resposta JSON para um objeto adequado
            var searchResult = JsonConvert.DeserializeObject<DeezerSearchResult>(response);

            // Retorne os resultados para o cliente
            return Ok(response);
        }
    }

    // Modelo para representar a resposta da Deezer
    public class DeezerSearchResult
    {
        // Adicione propriedades conforme necessário para mapear a resposta da Deezer
        // Exemplo: public List<DeezerTrack> Tracks { get; set; }
    }

    // Exemplo de modelo para representar uma faixa na resposta da Deezer
    public class DeezerTrack
    {
        // Adicione propriedades conforme necessário para mapear os detalhes da faixa
        // Exemplo: public string Title { get; set; }
    }
}
