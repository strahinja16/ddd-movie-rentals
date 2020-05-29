using System;
namespace WebApi.DTO
{
    public class PromoCodeDto
    {
        public Guid MovieId { get; set; }

        public DateTime PromoEnd { get; set; }

        public int Percentage { get; set; }
    }
}
