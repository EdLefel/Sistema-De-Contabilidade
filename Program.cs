
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BancoDeDados;
using BancoDeDados.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BancoDeDados.services;
using DinkToPdf;
using DinkToPdf.Contracts;
using Services;
using Services.GlobalVars;
using BancoDeDados.Services.Vendas;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AppState>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(sp.GetRequiredService<AppState>().GlobalUrl) });
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<VendasService>();

builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));



// Registra o Blazored.SessionStorage para usar o sessionStorage
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();   // Para LocalStorage

// Registra o CustomAuthenticationStateProvider como o provedor de estado de autenticação
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// Habilita autorização
builder.Services.AddAuthorizationCore();


await builder.Build().RunAsync();
