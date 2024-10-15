using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Services.GlobalVars;

namespace BancoDeDados.Services.Vendas
{
    public class VendasService
    {
        private readonly HttpClient _httpClient;

        public VendasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obter todas as vendas (READ)
        public async Task<List<Venda>> GetVendasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Venda>>("api/Vendaspedidos");
        }

        // Obter venda por ID (READ)
        public async Task<Venda> GetVendaByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Venda>($"api/Vendaspedidos/{id}");
        }

        // Criar nova venda (CREATE)
        public async Task CreateVendaAsync(Venda venda)
        {
            await _httpClient.PostAsJsonAsync("api/Vendaspedidos", venda);
        }

        // Atualizar uma venda (UPDATE)
        public async Task UpdateVendaAsync(Venda venda)
        {
            await _httpClient.PutAsJsonAsync($"api/Vendaspedidos/{venda.Id}", venda);
        }

        // Excluir uma venda (DELETE)
        public async Task DeleteVendaAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Vendaspedidos/{id}");
        }

        // Adicionando um método para buscar vendas por período
        public async Task<List<Venda>> GetVendasByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            return await _httpClient.GetFromJsonAsync<List<Venda>>($"api/Vendaspedidos?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");
        }

    }

    public class Venda
    {
        public int Id { get; set; }
        public string NomeUser { get; set; } = AppState.UserName;
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public string ClienteNome { get; set; } = "";
        public string ProdutoNome { get; set; } = "";
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public decimal DividaValor { get; set; }
        public string Descricao { get; set; } = "";
        public DateTime? DataDaVenda { get; set; }
    }
}
