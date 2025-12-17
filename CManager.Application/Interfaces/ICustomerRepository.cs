using CManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Application.Interfaces
{
    public interface ICustomerRepository
    {
        ResponseResultObject<IEnumerable<Customer>> GetAllCustomers();

        ResponseResult SaveAllCustomers(IEnumerable<Customer> customers);

        ResponseResult AddCustomer(Customer customer);

        ResponseResultObject<Customer> GetCustomerByEmail(string email);

        ResponseResult RemoveCustomerById(string id);


    }
}
