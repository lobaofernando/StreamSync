using Microsoft.AspNetCore.Mvc;
using StreamSync.Services.Interfaces;

namespace StreamSync.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeezerController : ControllerBase
    {
        private readonly IDeezerApiService _deezerApiService;
        private readonly IStreamSyncService _streamSyncService;

        public DeezerController(IDeezerApiService deezerApiService, IStreamSyncService streamSyncService)
        {
            _deezerApiService = deezerApiService;
            _streamSyncService = streamSyncService;
        }

        [HttpGet("Converter/{link}")]
        public async Task<IActionResult> Converter(string link)
        {
            var resultado = await _deezerApiService.Link(link);

            return Ok(resultado);
        }

        [HttpGet("Procurar/{consulta}/{tipo}")]
        public async Task<IActionResult> Procurar(string consulta, string tipo)
        {
            var resultado = await _deezerApiService.Procurar(consulta, tipo);

            return Ok(resultado);
        }

        [HttpGet("Trilha/{id}")]
        public async Task<IActionResult> Trilha(Int64 id)
        {
            var resultado = await _deezerApiService.Trilha(id);

            return Ok(resultado);
        }

        [HttpGet("Album/{id}/{mercado}")]
        public async Task<IActionResult> Album(Int64 id, string mercado)
        {
            var resultado = await _deezerApiService.Album(id, mercado);

            return Ok(resultado);
        }

        [HttpGet("Lista_de_musica/{id}/{mercado}")]
        public async Task<IActionResult> Lista_de_musica(Int64 id)
        {
            var resultado = await _deezerApiService.Lista_de_musica(id);

            return Ok(resultado);
        }

    }
}
