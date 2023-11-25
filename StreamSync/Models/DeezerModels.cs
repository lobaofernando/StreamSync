using System;
using System.Collections.Generic;


public class DeezerSearchResult
{
    public List<Track> Data { get; set; }
    public string Next { get; set; }
    public int Total { get; set; }

    public class ExternalUrls
    {
        public string Spotify { get; set; }
    }

    public class Artist
    {
        public ExternalUrls ExternalUrls { get; set; }
        public string Href { get; set; }
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class Image
    {
        public int Height { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
    }

    public class Album
    {
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string CoverSmall { get; set; }
        public string CoverMedium { get; set; }
        public string CoverBig { get; set; }
        public string CoverXl { get; set; }
        public string Md5Image { get; set; }
        public string Tracklist { get; set; }
        public string Type { get; set; }
    }

    public class Track
    {
        public Int64 Id { get; set; }
        public bool Readable { get; set; }
        public string Title { get; set; }
        public string TitleShort { get; set; }
        public string TitleVersion { get; set; }
        public string Link { get; set; }
        public int Duration { get; set; }
        public int Rank { get; set; }
        public bool ExplicitLyrics { get; set; }
        public int ExplicitContentLyrics { get; set; }
        public int ExplicitContentCover { get; set; }
        public string Preview { get; set; }
        public string Md5Image { get; set; }
        public Artist Artist { get; set; }
        public Album Album { get; set; }
        public string Type { get; set; }
    }
}
