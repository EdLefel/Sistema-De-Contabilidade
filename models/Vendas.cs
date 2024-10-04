namespace Models.Vendas{    
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