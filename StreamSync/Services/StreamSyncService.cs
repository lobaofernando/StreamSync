using StreamSync.Services.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace StreamSync.Services
{
    public class StreamSyncService : IStreamSyncService
    {
        private readonly ISpotifyApiService _spotifyApiService;
        private readonly IDeezerApiService _deezerApiService;

        public StreamSyncService(ISpotifyApiService spotifyApiService, IDeezerApiService deezerApiService)
        {
            _spotifyApiService = spotifyApiService;
            _deezerApiService = deezerApiService;
        }

        public async Task<string> Converter(string link)
        {

            if (link.Contains("spotify"))
            {

                string id = ExtractSpotifyTrackId(link);

                if (id.Equals("erro"))
                {
                    return "Não foi possível achar a trilha!";
                }

                var result = await _spotifyApiService.Trilha(id);

                SpotifySearchResult.Track objetospotify = Newtonsoft.Json.JsonConvert.DeserializeObject<SpotifySearchResult.Track>(result);

                var resultDeezer = await _deezerApiService.Procurar(objetospotify.Name, "track");

                DeezerSearchResult objetoDeezer = Newtonsoft.Json.JsonConvert.DeserializeObject<DeezerSearchResult>(resultDeezer);

                return objetoDeezer.Data[0].Link;

            }
            else if (link.Contains("deezer"))
            {
                var linkTrilha = await _deezerApiService.Link(link.Trim());

                Int64 id = ExtractDeezerTrackId(linkTrilha);

                if (id == -1)
                {
                    return "Não foi possível achar a trilha!";
                }

                var result = await _deezerApiService.Trilha(id);

                DeezerSearchResult.Track objetoDeezer = Newtonsoft.Json.JsonConvert.DeserializeObject<DeezerSearchResult.Track>(result);


                var resultSpotify = await _spotifyApiService.Procurar(objetoDeezer.Title, "track");

                SpotifySearchResult objetospotify = Newtonsoft.Json.JsonConvert.DeserializeObject<SpotifySearchResult>(resultSpotify);

                return "https://open.spotify.com/intl-pt/track/" + objetospotify.Tracks.Items[0].Id;
            }

            return "Não foi possível achar a trilha!";
        }

        static string ExtractSpotifyTrackId(string spotifyLink)
        {
            string pattern = @"track\/(.*?)\?si=";

            Match match = Regex.Match(spotifyLink, pattern);

            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            else
            {
                return "erro";
            }
        }

        static Int64 ExtractDeezerTrackId(string inputString)
        {
            try
            {
                string pattern = @"\/track\/(\d+)";

                Match match = Regex.Match(inputString, pattern);

                if (match.Success)
                {
                    if (Int64.TryParse(match.Groups[1].Value, out long trackId))
                    {
                        return trackId;
                    }
                }

                return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao extrair o Track ID: {ex.Message}");
                return -1;
            }
        }
    }
}

