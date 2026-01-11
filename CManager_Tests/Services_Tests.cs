
using CManager.Application.Interfaces;
using CManager.Application.Services;
using CManager.Domain.Models;
using NSubstitute;


namespace CManager_Tests;

public class Services_Tests
{
    [Fact]
    public void AddCustomer_ShouldReturnSuccess_WhenCustomerIsAdded()
    {
        //Arrange
        var customerRepository = Substitute.For<ICustomerRepository>();
        customerRepository.AddCustomer(Arg.Any<Customer>())
            .Returns(new ResponseResult
            {
                IsSuccess = true,
                Message = "Customer added successfully."
            });

        var customerService = new CustomerService(customerRepository);

        var customerRequest = new CustomerRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john@domain.com",
        };
        //Act
        var result = customerService.AddCustomer(customerRequest);

        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Customer added successfully.", result.Message);
    }
    [Fact]
    public void GetAllCustomers_ShouldReturnListOfCustomers()
    {
        //Arrange
        var customerRepository = Substitute.For<ICustomerRepository>();
        customerRepository.GetAllCustomers()
            .Returns(new ResponseResultObject<IEnumerable<Customer>>
            {
                IsSuccess = true,
                Message = "Customers retrieved successfully.",
                Data = new List<Customer>
                {
                    new Customer { Id = "1", FirstName = "John", LastName = "Doe", Email = "john@domain.com" }
                }
            });
        var customerService = new CustomerService(customerRepository);
        //Act
        var result = customerService.GetAllCustomers();
        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Customers retrieved successfully.", result.Message);
        Assert.Single(result.Data!);
    }
    [Fact]
    public void GetCustomerByEmail_ShouldReturnCustomer_WhenEmailExists()
    {
        //Arrange
        var customerRepository = Substitute.For<ICustomerRepository>();

        var customer = new Customer
        {
            Id = "1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john@domain.com"
        };

        customerRepository.GetCustomerByEmail(Arg.Any<string>())
            .Returns(new ResponseResultObject<Customer>
            {
                IsSuccess = true,
                Message = "Customer retrieved successfully.",
                Data = new Customer { Id = "1", FirstName = "John", LastName = "Doe", Email = "john@domain.com" }
            });
        var customerService = new CustomerService(customerRepository);
        //Act
        var result = customerService.GetCustomerByEmail(customer.Email);

        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Customer retrieved successfully.", result.Message);
        Assert.Equal(customer.Email, result.Data!.Email);
    }

    [Fact]
    public void RemoveCustomerByEmail_ShouldReturnSuccess_WhenCustomerIsRemoved()
    {
        //Arrange
        var customerRepository = Substitute.For<ICustomerRepository>();
        customerRepository.RemoveCustomerByEmail(Arg.Any<string>())
            .Returns(new ResponseResult
            {
                IsSuccess = true,
                Message = "Customer removed successfully."
            });
        var customerService = new CustomerService(customerRepository);
        var email = "john@domain.com";

        //Act
        var result = customerService.RemoveCustomerByEmail(email);
        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Customer removed successfully.", result.Message);
    }
    [Fact]


    //Det här testet fick jag hjälp med från chatGPT eftersom att jag hade svårt att få till det själv. Den behöver ju populera så att emailen redan existerar.
    public void UpdateCustomer_ShouldReturnSuccess_WhenCustomerIsUpdated()
    {
        //Arrange
        var customerRepository = Substitute.For<ICustomerRepository>();

        var customer = new Customer
        {
            Id = "1",
            FirstName = "John",
            LastName = "Doe",
            Email = "john@domain.com",
        };

        customerRepository.GetCustomerByEmail(customer.Email)
         .Returns(new ResponseResultObject<Customer>
         {
             IsSuccess = true,
             Message = "Found",
             Data = new Customer { Email = customer.Email }
         });

        customerRepository.UpdateCustomer(Arg.Any<Customer>())
        .Returns(new ResponseResult
        {
            IsSuccess = true,
            Message = "Customer updated successfully."
        });

        var customerService = new CustomerService(customerRepository);

        //Act
        var result = customerService.UpdateCustomer(customer);

        //Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Customer updated successfully.", result.Message);

    }
}
