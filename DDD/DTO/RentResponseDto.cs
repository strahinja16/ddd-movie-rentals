using System;
using Core.Models;

namespace WebApi.DTO
{
    public class RentResponseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string MovieStream { get; set; }
    }
}
