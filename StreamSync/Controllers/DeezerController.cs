using System;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using FuzzyString;

namespace NZWalksAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeezerController : ControllerBase
    {

        private readonly ILogger<DeezerController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly string deezerApiUrl = "http://localhost:8082/integracao/deezer/";

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

        [HttpGet("Procurar/{consulta}/{tipo}")]
        public async Task<IActionResult> DeezerSearch(string consulta, string tipo)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = deezerApiUrl + "procurar?q=" + tipo + ":%22" + Uri.EscapeDataString(consulta) + "%22";

            // Fa�a a requisi��o HTTP para a API da Deezer
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        [HttpGet("Acompanhar/{id}")]
        public async Task<IActionResult> DeezerTrilha(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = deezerApiUrl + "Acompanhar/" + id;

            // Fa�a a requisi��o HTTP para a API da Deezer
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        [HttpGet("Album/{id}/{mercado}")]
        public async Task<IActionResult> DeezerAlbum(string id, string mercado)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = deezerApiUrl + "album/" + id + "&market=" + mercado;

            // Fa�a a requisi��o HTTP para a API da Deezer
            HttpResponseMessage response = await httpClient.GetAsync(request);

            // Retornar conteudo como string/json
            string conteudo = await response.Content.ReadAsStringAsync();

            // Retorne os resultados para o cliente
            return Ok(conteudo);
        }

        [HttpGet("Lista_de_musica/{id}/{mercado}")]
        public async Task<IActionResult> DeezerLista_de_musica(string id)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var request = deezerApiUrl + "Lista_de_musica/" + id;

            // Fa�a a requisi��o HTTP para a API da Deezer
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

    // Modelo para representar a resposta da Deezer
    public class DeezerSearchResult
    {
        // Adicione propriedades conforme necess�rio para mapear a resposta da Deezer
        // Exemplo: public List<DeezerTrack> Tracks { get; set; }
    }

    // Exemplo de modelo para representar uma faixa na resposta da Deezer
    public class DeezerTrack
    {
        // Adicione propriedades conforme necess�rio para mapear os detalhes da faixa
        // Exemplo: public string Title { get; set; }
    }
}
