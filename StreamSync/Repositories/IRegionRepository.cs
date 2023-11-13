using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetById(Guid id);
        Task<bool> AddRegion(Region region);
        Task<Region> UpdateRegion(Guid id, UpdateRegionRequestDto region);
        Task<Region> DeleteRegion(Guid id);
    }
}
