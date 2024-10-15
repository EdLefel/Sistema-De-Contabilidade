using Services.GlobalVars;

namespace Models.Venda{    
    public class Vendas{
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