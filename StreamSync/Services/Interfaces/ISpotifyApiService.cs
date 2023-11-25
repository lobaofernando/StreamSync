namespace StreamSync.Services.Interfaces
{
    public interface ISpotifyApiService
    {
        public Task<string> Procurar(string consulta, string tipo);

        public Task<string> Trilha(string id);

        public Task<string> Album(string id, string mercado);

        public Task<string> Lista_de_musica(string id);

    }
}
