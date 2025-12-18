using CManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Application.Interfaces
{
    public interface ICustomerRepository
    {
        ResponseResultObject<IEnumerable<Customer>> GetAllCustomers();

        ResponseResult AddCustomer(Customer customer);

        ResponseResultObject<Customer> GetCustomerByEmail(CustomerRequest customer);


        ResponseResult RemoveCustomerById(Customer customer);

        void UpdateCustomerList();

        void SaveAllCustomers(List<Customer> customers);

    }
}
