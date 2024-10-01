using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using BancoDeDados.models.Clients;

namespace BancoDeDados.services
{
    public class ClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obter todos  (READ)
        public async Task<List<Client>>GetClientsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Client>>("api/clients");
        }

        // Obter por ID (READ)
        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Client>($"api/clients/{id}");
        }

        // Criar novo (CREATE)
        public async Task CreateClienttAsync(Client client)
        {
            await _httpClient.PostAsJsonAsync("api/clients", client);
        }

        // Atualizar (UPDATE)
        public async Task UpdateClientAsync(Client client)
        {
            await _httpClient.PutAsJsonAsync($"api/clients/{client.Id}", client);
        }

        // Excluir (DELETE)
        public async Task DeleteClientAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/clients/{id}");
        }
    }

}
