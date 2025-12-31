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

        ResponseResultObject<Customer> GetCustomerByEmail(string email);


        ResponseResult RemoveCustomerByEmail(string customer);

        void UpdateCustomerList();

        void SaveAllCustomers(List<Customer> customers);

    }
}
