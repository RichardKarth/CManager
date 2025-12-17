
using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Serializations;
using System.Text.Json;

namespace CManager.Infrastructure.Repositories;

public sealed class FileStorageRepository(string filePath) : ICustomerRepository
{

    private readonly string _filePath = filePath;

    public ResponseResult AddCustomer(Customer customer)
    {
        try
        {
            var result = JsonFormatter.SerializeObject(customer);
            File.WriteAllText(_filePath, result);

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Customer added successfully."
            };
        }
        catch
        {
            return new ResponseResult
            {
                IsSuccess = false,
                Message = "An error occurred while adding the customer."
            };
        }
    }

    public ResponseResultObject<IEnumerable<Customer>> GetAllCustomers()
    {
        try
        {
            var json = File.ReadAllText(_filePath);

            var customers = JsonFormatter.DeserializeObject<IEnumerable<Customer>>(json);

            return new ResponseResultObject<IEnumerable<Customer>>
            {
                IsSuccess = true,
                Message = "Customers retrieved successfully.",
                Data = customers
            };
        }
        catch
        {
            return new ResponseResultObject<IEnumerable<Customer>>
            {
                IsSuccess = false,
                Message = "An error occurred while retrieving customers.",
                Data = []
            };
        }
    }

    public ResponseResultObject<Customer> GetCustomerByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public ResponseResult RemoveCustomerById(string id)
    {
        throw new NotImplementedException();
    }

    public ResponseResult SaveAllCustomers(IEnumerable<Customer> customers)
    {
        throw new NotImplementedException();
    }
}
