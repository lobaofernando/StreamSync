using Microsoft.AspNetCore.Mvc;
using StreamSync.Services.Interfaces;

namespace StreamSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyController : ControllerBase
    {
        private readonly ISpotifyApiService _spotiftApiService;
        private readonly IStreamSyncService _streamSyncService;


        public SpotifyController(ISpotifyApiService spotiftApiService, IStreamSyncService streamSyncService)
        {
            _spotiftApiService = spotiftApiService;
            _streamSyncService = streamSyncService;
        }

        [HttpGet("Converter/{link}")]
        public async Task<IActionResult> Converter(string link)
        {
            var resultado = await _streamSyncService.Converter(link);

            return Ok(resultado);
        }

        [HttpGet("Procurar/{consulta}/{tipo}")]
        public async Task<IActionResult> Procurar(string consulta, string tipo)
        {
            var resultado = await _spotiftApiService.Procurar(consulta, tipo);

            return Ok(resultado);
        }

        [HttpGet("Trilha/{id}")]
        public async Task<IActionResult> Trilha(string id)
        {
            var resultado = await _spotiftApiService.Trilha(id);

            return Ok(resultado);
        }

        [HttpGet("Album/{id}/{mercado}")]
        public async Task<IActionResult> Album(string id, string mercado)
        {
            var resultado = await _spotiftApiService.Album(id, mercado);

            return Ok(resultado);
        }

        [HttpGet("Lista_de_musica/{id}/{mercado}")]
        public async Task<IActionResult> Lista_de_musica(string id)
        {
            var resultado = await _spotiftApiService.Lista_de_musica(id);

            return Ok(resultado);
        }

    }
}
