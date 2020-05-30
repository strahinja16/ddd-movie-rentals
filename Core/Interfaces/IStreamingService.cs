using System;
using Core.Models;

namespace Core.Interfaces
{
    public interface IStreamingService
    {
        string GetMovieStreamWithDownload(Movie movie);

        string GetMovieStream(Movie movie);
    }
}
