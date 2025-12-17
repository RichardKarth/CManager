
using CManager.Application.Interfaces;
using CManager.Application.Services;
using CManager.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddSingleton<ICustomerRepository>(new FileStorageRepository(@"c:\data\customers.json"));
builder.Services.AddSingleton<ICustomerService, CustomerService>();

var app = builder.Build();