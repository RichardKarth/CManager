using CManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Application.Interfaces
{
    public interface ICustomerService
    {
        ResponseResult AddCustomer(CustomerRequest customer);

        ResponseResultObject<Customer> GetCustomerByEmail(CustomerRequest customer);

        ResponseResultObject<IEnumerable<Customer>> GetAllCustomers();

        ResponseResult RemoveCustomerById(CustomerRequest customer);
    }
}
