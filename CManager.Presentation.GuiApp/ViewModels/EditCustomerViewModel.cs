
using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace CManager.Presentation.GuiApp.ViewModels;

public partial class EditCustomerViewModel : ObservableObject
{
    private readonly ICustomerService _customerService;
    private readonly IServiceProvider _serviceProvider;



    public EditCustomerViewModel(ICustomerService customerService, IServiceProvider serviceProvider)
    {
        _customerService = customerService;
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private string _title = "Edit Customer";

    [ObservableProperty]
    private Customer _customer = new();

    [RelayCommand]
    private void SaveChanges()
    {
        var result = _customerService.UpdateCustomer(Customer);
        if (result.IsSuccess)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();
        }

    }

    [RelayCommand]
    public void BackToMenuView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();

    }
     
        
     


}
