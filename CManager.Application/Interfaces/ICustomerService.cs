using CManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Application.Interfaces
{
    public interface ICustomerService
    {
        ResponseResult AddCustomer(CustomerRequest customer);

        ResponseResultObject<Customer> GetCustomerByEmail(string email);

        ResponseResultObject<IEnumerable<Customer>> GetAllCustomers();

        ResponseResult RemoveCustomerByEmail(string customer);
    }
}
