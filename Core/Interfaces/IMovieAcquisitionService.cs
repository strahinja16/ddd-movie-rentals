using System;
using Core.Models;
using Core.Models.Responses;

namespace Core.Interfaces
{
    public interface IMovieAcquisitionService : IDomainService
    {
        RentResponse RentMovie(Customer customer, Movie movie);

        PurchaseResponse PurchaseMovie(Customer customer, Movie movie);
    }
}
