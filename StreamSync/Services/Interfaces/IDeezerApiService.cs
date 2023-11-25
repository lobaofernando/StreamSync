namespace StreamSync.Services.Interfaces
{
    public interface IDeezerApiService
    {
        public Task<string> Procurar(string consulta, string tipo);

        public Task<string> Trilha(Int64 id);

        public Task<string> Album(Int64 id, string mercado);

        public Task<string> Lista_de_musica(Int64 id);
        public Task<string> Link(string link);

    }
}
