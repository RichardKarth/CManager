using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Net.WebSockets;


namespace CManager.Presentation.GuiApp.ViewModels;

public partial class DeleteCustomerViewModel : ObservableObject
{
   private readonly ICustomerService _customerService;
   private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableCollection<Customer> customers = new();



    public DeleteCustomerViewModel(ICustomerService customerService, IServiceProvider serviceProvider)
    {
        _customerService = customerService;
        _serviceProvider = serviceProvider;


        var result = customerService.GetAllCustomers();

        if (result.IsSuccess && result.Data != null)
        {
            Customers = new ObservableCollection<Customer>(result.Data);
        }

        _serviceProvider = serviceProvider;
    }

    [RelayCommand]
    public void Delete(Customer customer)
    {
        var result = _customerService.RemoveCustomerByEmail(customer.Email);
        if (result.IsSuccess)
        {
            Customers.Remove(customer);
        }
    }

    [RelayCommand]
    public void BackToMenuView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();

    }




}
