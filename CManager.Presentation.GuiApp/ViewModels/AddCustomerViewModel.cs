using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CManager.Presentation.GuiApp.ViewModels;

public partial class AddCustomerViewModel(IServiceProvider serviceProvider, ICustomerService customerService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ICustomerService _customerService = customerService;

    [ObservableProperty]
    private CustomerRequest _customer = new();


    [ObservableProperty]
    private string _title = "Add Customer";

    [RelayCommand]
    private void BackToMenuView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
    }

    [RelayCommand]
    private void AddCustomer()
    {
       var result = _customerService.AddCustomer(Customer);

        if (result.IsSuccess)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
        }
    }

}
