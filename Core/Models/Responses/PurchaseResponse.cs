using System;
namespace Core.Models.Responses
{
    public class PurchaseResponse
    {
        public MoviePurchase MoviePurchase { get; private set; }

        public string MovieStreamWithDownload { get; private set; }

        public PurchaseResponse(MoviePurchase moviePurchase, string movieStreamWithDownload)
        {
            MoviePurchase = moviePurchase;
            MovieStreamWithDownload = movieStreamWithDownload;
        }
    }
}
