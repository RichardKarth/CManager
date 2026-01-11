
using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CManager.Infrastructure.Serializations;

namespace CManager.Infrastructure.Repositories;

public class FileStorageRepository(string filePath) : ICustomerRepository
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

    public ResponseResultObject<Customer> GetCustomerByEmail(string email)
    {
        try
        {
            var json = File.ReadAllText(_filePath);

            var customers = JsonFormatter.DeserializeObject<IEnumerable<Customer>>(json);

            return new ResponseResultObject<Customer>
            {
                IsSuccess = true,
                Message = "Customers retrieved successfully.",
                Data = customers?.FirstOrDefault(c => c.Email.Equals(email))
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

    public ResponseResult RemoveCustomerByEmail(string customer)
    {
        try
        {
            
            UpdateCustomerList();

            var deletedCustomer = _customers.FirstOrDefault(c => c.Email == customer);

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

    public ResponseResult UpdateCustomer(Customer customer)
    {
        try
        {
            UpdateCustomerList();

            var existing = _customers.FirstOrDefault(c => c.Email == customer.Email);
            if (existing == null)
            {
                return new ResponseResult
                {
                    IsSuccess = false,
                    Message = "Customer not found."
                };
            }

            existing.FirstName = customer.FirstName;
            existing.LastName = customer.LastName;
            existing.PhoneNumber = customer.PhoneNumber;
            

            SaveAllCustomers(_customers);

            return new ResponseResult
            {
                IsSuccess = true,
                Message = "Customer updated successfully."
            };
        }
        catch
        {
            return new ResponseResult
            {
                IsSuccess = false,
                Message = "An error occurred while updating the customer."
            };
        }
    }



    public void UpdateCustomerList()
    {
        try
        {
            EnsureDirectoryExists();

            if (!File.Exists(_filePath))
            {
                _customers = new List<Customer>();
                return;
            }


            var json = File.ReadAllText(_filePath);
            var customers = JsonFormatter.DeserializeObject<List<Customer>>(json);  
            _customers = customers ?? new List<Customer>();
        }
        catch
        {
            _customers = new List<Customer>();
        }

    }


    // Denna metod skrevs helt av chatGPT, den kollar så att katalogen för filvägen finns, om inte skapas den.

    private void EnsureDirectoryExists()
    {
        var dir = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);
    }

    
}
