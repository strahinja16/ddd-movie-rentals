using System;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class StreamingService : IStreamingService
    {
        public string GetMovieStreamWithDownload(Movie movie)
        {
            return $"{GetBaseUrl()}?movie={movie.Name}&download=true";
        }

        public string GetMovieStream(Movie movie)
        {
            return $"{GetBaseUrl()}?movie={movie.Name}";
        }

        private string GetBaseUrl()
        {
            return "https://short.lnk/watch";
        }
    }
}
