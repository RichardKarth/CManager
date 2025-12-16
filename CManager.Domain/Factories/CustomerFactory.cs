
using CManager.Domain.Exceptions;
using CManager.Domain.Models;
using CManager.Domain.Helpers;

namespace CManager.Domain.Factories;

public class CustomerFactory
{
    public static Customer Create (CustomerRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName))
        {
            throw new DomainException("Firstname is required");
        }
        if (string.IsNullOrWhiteSpace(request.LastName))
        {
            throw new DomainException("Lastname is required");
        }
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            throw new DomainException("Email is required");
        }
        else
        {
            return new Customer
            {
                Id = GuidGenerator.GenerateGuid(),
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                Email = request.Email.Trim(),
                PhoneNumber = request.PhoneNumber?.Trim()
            };
        }
    }
}
