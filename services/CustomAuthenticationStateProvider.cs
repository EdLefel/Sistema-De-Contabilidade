using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Models.AddModels;
using System;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using BancoDeDados;
using Services.GlobalVars;

namespace Services{
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly ISessionStorageService _sessionStorage;
    private readonly ILocalStorageService _localStorage;

    public CustomAuthenticationStateProvider(ISessionStorageService sessionStorage, ILocalStorageService localStorage)
    {
    _sessionStorage = sessionStorage;
    _localStorage = localStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // Verifica se há um token armazenado no sessionStorage
        var token = await _sessionStorage.GetItemAsync<string>("authToken");

        // Se não houver token, usuário está deslogado (estado anônimo)
        if (string.IsNullOrEmpty(token))
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            return new AuthenticationState(anonymousUser);
        }

        // Se houver token, usuário está logado
        var valor = await _sessionStorage.GetItemAsync<string>("chave");
        //var userName = await _sessionStorage.GetItemAsync<string>("");

        var claimsIdentity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, "username")
        }, "apiauth_type");

        var user = new ClaimsPrincipal(claimsIdentity);
        Console.WriteLine();
        return new AuthenticationState(user);
    }

    // Método para autenticar o usuário e salvar o token no sessionStorage
    public async Task MarkUserAsAuthenticated(string token, string username)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, username)
        }, "apiauth_type");

        var user = new ClaimsPrincipal(identity);

        // Armazena o token no sessionStorage
        await _sessionStorage.SetItemAsync("authToken", token);

        // Notifica que o estado de autenticação mudou
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

        AppState.UserName = username;
        
    }

    // Método para deslogar o usuário e remover o token
    public async Task MarkUserAsLoggedOut(){
    // Remove o token de autenticação do sessionStorage
    await _sessionStorage.RemoveItemAsync("authToken");

    // Cria um estado de usuário anônimo
    var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());

    // Notifica que o estado de autenticação mudou para anônimo
    NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
    }

}
}