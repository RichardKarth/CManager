
using CManager.Presentation.GuiApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Input;

namespace CManager.Presentation.GuiApp.ViewModels;

public partial class MenuViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public MenuViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

    }

    [ObservableProperty]
    private string _title = "CManager Menu";



    [RelayCommand]
    private void OpenAddCustomerView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddCustomerViewModel>();
    }
    [RelayCommand]
    private void OpenViewCustomersView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ViewCustomerViewModel>();
    }
    [RelayCommand]
    private void OpenDeleteCustomerView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<DeleteCustomerViewModel>();
    }
    [RelayCommand]
    private void OpenSpecificCustomerView()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<SpecificCustomerViewModel>();
    }
}
