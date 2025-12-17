
using CManager.Application.Interfaces;
using CManager.Domain.Models;

namespace CManager.Presentation.ConsoleApp.Controllers;

public class MenuController
{
    private readonly ICustomerService _customerService;
    

    public MenuController(ICustomerService customerService)
    {
        _customerService = customerService;

    }
}
