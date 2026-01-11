
using CManager.Application.Interfaces;
using CManager.Domain.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
namespace CManager.Presentation.GuiApp.ViewModels;

public partial class ViewCustomerViewModel : ObservableObject
{
    private readonly ICustomerService _customerService;
    private readonly IServiceProvider _serviceProvider;


    [ObservableProperty]
    private ObservableCollection<Customer> _customers;

    public ViewCustomerViewModel(ICustomerService customerService, IServiceProvider serviceProvider )
    {
        _customerService = customerService;
        _serviceProvider = serviceProvider;

        var result = _customerService.GetAllCustomers();

        //Fick hjälp av ChatGPT med denna rad nedan för att jag får tillbaka resultResponse och inte en IEnumerable direkt. Det den gör är att paketera upp resultatets Data och sätter det som ObservableCollection
        Customers = result.IsSuccess && result.Data != null
            ? new ObservableCollection<Customer>(result.Data)
            : new ObservableCollection<Customer>();
    }

    [ObservableProperty]
    private string _title = "View Customers";


    [RelayCommand]
    private void Edit(Customer customer)
    {

        var editCustomerViewModel = _serviceProvider.GetRequiredService<EditCustomerViewModel>();
        editCustomerViewModel.Customer = customer;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editCustomerViewModel;

    }
    [RelayCommand]
    public void BackToMenuView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<MenuViewModel>();

    }

}
