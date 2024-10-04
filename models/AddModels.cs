using System.ComponentModel.DataAnnotations;
using global::Services.GlobalVars;

namespace Models.AddModels{
    public class CadastroClientModel{
        public int Id { get; set; }
        [Required]
        public string Tipopessoa { get; set; }
        public string Razaosocial { get; set; }
        public string Nomefic { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Telefonecontato1 { get; set; }
        public string Telefonecontato2 { get; set; }
        public string Cpfcnpj { get; set; }
        public string Rg { get; set; }
        public DateTime Datacadastro { get; set; } = DateTime.Now;
        public DateTime Datanascimento { get; set; } = DateTime.Now;
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public int Devendo { get; set; } 
    }


    public class CadastroProductModel{
        //private readonly AppState _appState;
        public int Id { get; set; }
        public string NomeUser { get; set; } = AppState.UserName;
        [Required]
        public string ProdutoNome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
        public string Valor { get; set; }
    }

        public class LoginRequest{
        public string NomeUser { get; set; }
        public string Password { get; set; }
    }

    public class Vendas{
        public int Id { get; set; }  // ID da Venda
        public int IdCliente { get; set; }  // ID do Cliente
        public int IdFuncionario { get; set; }  // ID do Funcionário
        //public DateTime DataVenda { get; set; }  // Data da Venda
        public decimal TotalVenda { get; set; }  // Total da Venda
        public string ItensVenda { get; set; }  // Lista de Itens da Venda
        public bool StatusVenda { get; set; }  // Status da Venda
        public int ParcelasVendas { get; set; }  // Pagamento da Venda
    }
}