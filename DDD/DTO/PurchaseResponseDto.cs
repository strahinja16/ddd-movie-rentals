using System;
using Core.Models;

namespace WebApi.DTO
{
    public class PurchaseResponseDto
    {
        public DateTime Date { get; private set; }

        public string Movie { get; private set; }

        public string MovieStreamWithDownload { get; set; }
    }
}
