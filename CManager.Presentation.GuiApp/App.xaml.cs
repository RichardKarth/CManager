
using CManager.Application.Interfaces;
using CManager.Application.Services;
using CManager.Infrastructure.Repositories;
using CManager.Presentation.GuiApp.ViewModels;
using CManager.Presentation.GuiApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace CManager.Presentation.GuiApp;

public partial class App : System.Windows.Application
{
    //här läggs dependecy injection, motsvarar programs.cs i console app

    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
        {
            services.AddSingleton<ICustomerRepository>(new FileStorageRepository(@"c:\data\customers.json"));
            services.AddSingleton<ICustomerService, CustomerService>();
            


            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();

            services.AddTransient<MenuViewModel>();
            services.AddTransient<MenuView>();

            services.AddTransient<AddCustomerViewModel>();
            services.AddTransient<AddCustomerView>();

            services.AddTransient<ViewCustomerViewModel>();
            services.AddTransient<ViewCustomerView>();

            services.AddTransient<EditCustomerViewModel>();
            services.AddTransient<EditCustomerView>();

            services.AddTransient<DeleteCustomerViewModel>();
            services.AddTransient<DeleteCustomerView>();

            services.AddTransient<SpecificCustomerViewModel>();
            services.AddTransient<SpecificCustomerView>();





        }).Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
