using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:7155/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // GET Data from database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            // Return the DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET SINGLE REGION (Get region by id)
        // GET: https://localhost:7155/api/regions/{ID}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Map domain models to DTOs
            var regionDomain = await regionRepository.GetById(id);

            if (regionDomain == null)
                return NotFound();

            // Return the DTOs
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST to create new region
        // POST: https://localhost:7155/api/regions
        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Use domain model to create region
            if (!await regionRepository.AddRegion(mapper.Map<Region>(addRegionRequestDto)))
            {
                return BadRequest();
            }

            // Map domain back to DTO
            var regionDto = mapper.Map<RegionDto>(addRegionRequestDto);

            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }

        // PUT EDIT SINGLE REGION (PUT region by id)
        // PUT: https://localhost:7155/api/regions/{ID}
        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto region)
        {
            // Map domain models to DTOs
            var regionDomain = await regionRepository.UpdateRegion(id, region);

            if (regionDomain == null)
                return NotFound();

            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // DELETE SINGLE REGION (DELETE region by id)
        // DELETE: https://localhost:7155/api/regions/{ID}
        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            // get the region from the database
            var regionDomain = await regionRepository.DeleteRegion(id);

            // check results
            if (regionDomain == null)
            {
                return NotFound();
            }

            // return regiondto with informations of the deleted item
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST to create multiple random new regions
        // POST: https://localhost:7155/api/regions
        [HttpPost("{qtd:int}")]
        public async Task<IActionResult> AddRandomRegions([FromRoute] int qtd)
        {

            for (int i = 0; i < qtd; i++)
            {
                // Map domain models to DTOs
                var regionDomain = new Region
                {
                    Code = DevHelper.RandomStringGenerator(2),
                    Name = DevHelper.RandomStringGenerator(10),
                    RegionImageUrl = "www." + DevHelper.RandomStringGenerator(10) + ".com/" + DevHelper.RandomStringGenerator(15),
                };

                await regionRepository.AddRegion(regionDomain);
            }

            return Ok("Criados " + qtd.ToString() + " objetos com sucesso!");
        }
    }
}
