using System;
using Core.Models;

namespace WebApi.DTO
{
    public class PurchaseResponseDto
    {
        public DateTime Date { get; set; }

        public string Movie { get; set; }

        public string MovieStreamWithDownload { get; set; }
    }
}
