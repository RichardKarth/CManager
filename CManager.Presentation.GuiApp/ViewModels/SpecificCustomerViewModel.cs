using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace CManager.Presentation.GuiApp.ViewModels;

public partial class SpecificCustomerViewModel : ObservableObject
{

    private readonly ICustomerService _customerService;
    private readonly IServiceProvider _serviceProvider;

   

    public SpecificCustomerViewModel(ICustomerService customerService, IServiceProvider serviceProvider)
    {
        _customerService = customerService;
        _serviceProvider = serviceProvider;
  
    }
    [ObservableProperty]
    private string _title = "Search Customer";

    [ObservableProperty]
    private Customer _customer;

    [ObservableProperty]
    private string searchEmail;

    [RelayCommand]
    private void GetCustomerByEmail(string email)
    {
        var result = _customerService.GetCustomerByEmail(email);
        if (result.IsSuccess && result.Data != null)
        {
           Customer = result.Data;
        }
    }
    [RelayCommand]
    public void BackToMenuView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();

    }





}
