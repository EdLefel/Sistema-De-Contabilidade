// Services/ProductService.cs
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BancoDeDados.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Obter todos os produtos (READ)
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/products");
        }

        // Obter produto por ID (READ)
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }

        // Criar novo produto (CREATE)
        public async Task CreateProductAsync(Product product)
        {
            await _httpClient.PostAsJsonAsync("api/products", product);
        }

        // Atualizar um produto (UPDATE)
        public async Task UpdateProductAsync(Product product)
        {
            await _httpClient.PutAsJsonAsync($"api/products/{product.Id}", product);
        }

        // Excluir um produto (DELETE)
        public async Task DeleteProductAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/products/{id}");
        }
    }

    public class Product
    {
        public int Id { get; set; }  // ID do Produto
        public string NomeUser { get; set; } = string.Empty;  // Nome do Usuário
        public string ProdutoNome { get; set; } = string.Empty;   // Nome do Produto
        public string Descricao { get; set; } = string.Empty;  // Descrição do Produto
        public string Imagem { get; set; } = string.Empty;  // Imagem do Produto
        public decimal Preco { get; set; } = 0;  // Preço do Produto
        public decimal  Quantidade { get; set; } = 0;  // Quantidade do Produto
        public string Valor { get; set; } = "0,0";
    }
}
