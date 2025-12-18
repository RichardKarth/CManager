
using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Serializations;
using System.Text.Json;

namespace CManager.Infrastructure.Repositories;

public sealed class FileStorageRepository(string filePath) : ICustomerRepository
{

    private readonly string _filePath = filePath;
    private List<Customer> _customers = [];

    public ResponseResult AddCustomer(Customer customer)
    {
        try
        {
            UpdateCustomerList();
            _customers.Add(customer);
            SaveAllCustomers(_customers);

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

    public ResponseResultObject<Customer> GetCustomerByEmail(CustomerRequest customer)
    {
        try
        {
            var json = File.ReadAllText(_filePath);

            var customers = JsonFormatter.DeserializeObject<IEnumerable<Customer>>(json);

            return new ResponseResultObject<Customer>
            {
                IsSuccess = true,
                Message = "Customers retrieved successfully.",
                Data = customers?.FirstOrDefault(c => c.Email.Equals(customer.Email))
            };
        }
        catch
        {
            return new ResponseResultObject<Customer>
            {
                IsSuccess = false,
                Message = "An error occurred while retrieving the customer.",
            };
        }
    }

    public ResponseResult RemoveCustomerById(Customer customer)
    {
        try
        {
            
            UpdateCustomerList();

            var deletedCustomer = _customers?.FirstOrDefault(c => c.Id == customer.Id);

            if (deletedCustomer == null)
            {
                return new ResponseResult
                {
                    IsSuccess = false,
                    Message = "Customer not found.",
                };
            }
            _customers.Remove(deletedCustomer);
            SaveAllCustomers(_customers);

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Customer deleted successfully.",
            };
        }
        catch
        {
            return new ResponseResult
            {
                IsSuccess = false,
                Message = "An error occurred while deleting the customer.",
            };
        }
    }

    public void SaveAllCustomers(List<Customer> customers)
    {
        try
        {
            var result = JsonFormatter.SerializeObject(customers);
            File.WriteAllText(_filePath, result);
        }
        catch
        {
            throw new Exception("An error occurred while saving customers.");
        }

    }

    public void UpdateCustomerList()
    {
        try
        {
            var json = File.ReadAllText(_filePath);
            var customers = JsonFormatter.DeserializeObject<List<Customer>>(json);  
            _customers = customers ?? new List<Customer>();
        }
        catch
        {
            _customers = new List<Customer>();
        }

    }
}
