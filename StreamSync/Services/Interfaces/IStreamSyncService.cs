namespace StreamSync.Services.Interfaces
{
    public interface IStreamSyncService
    {
        public Task<string> Converter(string link);
    }
}
