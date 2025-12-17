
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

        var result = JsonFormatter.SerializeObject(customer);

        File.WriteAllText(_filePath, result);

        throw new NotImplementedException();
    }

    public ResponseResultObject<IEnumerable<Customer>> GetAllCustomers()
    {
        throw new NotImplementedException();
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
