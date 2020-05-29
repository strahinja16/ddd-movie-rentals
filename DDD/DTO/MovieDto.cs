using System;
using Core.Models;

namespace WebApi.DTO
{
    public class MovieDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Genre Genre { get; set; }

        public DateTime CreatedAt { get; set; }

        public Price Price { get; set; }
    }
}
