﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomersService customersService;

        public CustomersController(ICustomersService customersService)
        {
            this.customersService = customersService;
        }

        [HttpGet("{id}")]
        public CustomerDto Get(Guid id)
        {
            return customersService.GetCustomerById(id);
        }

        [HttpPost("")]
        public CustomerDto CreateCustomer([FromBody] CreateCustomerDto createCustomerDto)
        {
            return customersService.CreateCustomer(createCustomerDto);
        }

        [HttpPut("{id}")]
        public CustomerDto EdtCreditCard(Guid id, [FromBody] EditCreditCardDto editCreditCardDto)
        {
            return customersService.EditCreditCard(id, editCreditCardDto.CreditCardValue);
        }

        [HttpPost("{id}/rent-movie")]
        public RentResponseDto RentMovie(Guid id, [FromBody] RentRequestDto rentRequestDto)
        {
            return customersService.RentMovie(id, rentRequestDto.MovieId);
        }

        [HttpPost("{id}/purchase-movie")]
        public PurchaseResponseDto PurchaseMovie(Guid id, [FromBody] PurchaseRequestDto purchaseRequestDto)
        {
            return customersService.PurchaseMovie(id, purchaseRequestDto.MovieId);
        }

        [HttpPost("{id}/watch-movie")]
        public WatchMovieResponseDto WatchMovie(Guid id, [FromBody] WatchMovieRequestDto watchMovieRequestDto)
        {
            return customersService.WatchMovie(id, watchMovieRequestDto.MovieId);
        }
    }
}
