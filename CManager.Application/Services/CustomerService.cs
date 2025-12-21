using CManager.Application.Interfaces;
using CManager.Application.Validators;
using CManager.Domain.Factories;
using CManager.Domain.Models;

namespace CManager.Application.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{

    private readonly ICustomerRepository _customerRepository = customerRepository;
    private List<Customer> _customers = [];

    public ResponseResult AddCustomer(CustomerRequest customer)
    {
        if (!NameValidator.IsValid(customer.FirstName))
        {
            return new ResponseResult
            {
                IsSuccess = false,
                Message = "Invalid first name."
            };
        }
        if (!LastNameValidator.IsValid(customer.LastName))
        {
            return new ResponseResult
            {
                IsSuccess = false,
                Message = "Invalid last name."
            };
        }
        if (!EmailValidator.IsValid(customer.Email))
        {
            return new ResponseResult
            {
                IsSuccess = false,
                Message = "Invalid email."
            };
        }

        var createdCustomer = CustomerFactory.Create(customer);

        var responseResult = _customerRepository.AddCustomer(createdCustomer);
        return responseResult;
    }

    public ResponseResultObject<IEnumerable<Customer>> GetAllCustomers()
    {
        var responseResultObject = _customerRepository.GetAllCustomers();
        return responseResultObject;
    }

    public ResponseResultObject<Customer> GetCustomerByEmail(string email)
    {
        var responseResultObject = _customerRepository.GetCustomerByEmail(email);
        return responseResultObject;
    }

    public ResponseResult RemoveCustomerByEmail(string customer)
    {
        
        var responseResult = _customerRepository.RemoveCustomerByEmail(customer);
        return responseResult;
    }
}
