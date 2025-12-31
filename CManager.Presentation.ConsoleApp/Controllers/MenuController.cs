
using CManager.Application.Interfaces;
using CManager.Domain.Models;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CManager.Presentation.ConsoleApp.Controllers;

public class MenuController(ICustomerService customerService)
{
    private readonly ICustomerService _customerService = customerService;

    public void Run()
    {
        var isOn = true;

        while (isOn)
        {
            ShowMenu();
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    var addCustomerController = AddCustomer();
                    Console.WriteLine(addCustomerController.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    GetAllCustomers();
                    break;
                case "3":
                    GetCustomerByEmail();
                    break;
                case "4":
                    DeleteCustomer();
                    break;
                case "5":
                    isOn = false;
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Customer Management System!");

            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. List All Customers");
            Console.WriteLine("3. View Customer");
            Console.WriteLine("4. Delete a Customer");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
        }

        ResponseResult AddCustomer()
        {
            Console.Clear();
            Console.Write("Enter First Name: ");
            var firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            var lastName = Console.ReadLine();
            Console.Write("Enter Email: ");
            var email = Console.ReadLine();
            Console.Write("Enter PhoneNumber: ");
            var phoneNumber = Console.ReadLine();

            var customerRequest = new CustomerRequest
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };
            var response = _customerService.AddCustomer(customerRequest);
            return response;
        }

        void GetAllCustomers()
        {
            Console.Clear();
            Get();
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
        }


        void GetCustomerByEmail(){

            Console.Clear();
            Console.Write("Enter the Email of the Customer you want to view: ");
            var email = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email cannot be empty. Press any key to continue...");
                Console.ReadKey();
               
            }
            var response = _customerService.GetCustomerByEmail(email);

            var customer = response.Data;

            Console.WriteLine(customer.Id);
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer.LastName);
            Console.WriteLine(customer.Email);
            Console.WriteLine(customer.PhoneNumber);
            Console.ReadKey();
        }
        void DeleteCustomer()
        {

            Console.Clear();

            Get();

            Console.Write("Enter the email adress of the user you want to remove:");
            var customerEmail = Console.ReadLine();
            _customerService.RemoveCustomerByEmail(customerEmail);

            Console.ReadKey();

        }

        void Get()
        {
            var customerList = _customerService.GetAllCustomers();

            foreach (var customer in customerList.Data)
            {
                Console.WriteLine($"- {customer.FirstName} {customer.LastName}, Email: {customer.Email}, Phone: {customer.PhoneNumber}");
            }
        }
    }  
}
