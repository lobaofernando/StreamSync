using Microsoft.AspNetCore.Mvc;
using StreamSync.Services.Interfaces;
using System.Net;

namespace StreamSync.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamSyncController : ControllerBase
    {
        private readonly IStreamSyncService _streamSyncService;

        public StreamSyncController(IStreamSyncService streamSyncService)
        {
            _streamSyncService = streamSyncService;
        }

        [HttpGet("Converter/{link}")]
        public async Task<IActionResult> Converter(string link)
        {
            var resultado = await _streamSyncService.Converter(WebUtility.UrlDecode(link));

            return Ok(resultado);
        }
    }
}
