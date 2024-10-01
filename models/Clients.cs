namespace BancoDeDados.models.Clients
{
    
public class Client
{
    public int Id { get; set; }
    public string Tipopessoa { get; set; }
    public string Razaosocial { get; set; }
    public string Nomefic { get; set; }
    public string Email { get; set; }
    public string Telefonecontato1 { get; set; }
    public string Telefonecontato2 { get; set; }
    public string Cpfcnpj { get; set; }
    public string Rg { get; set; }
    public DateTime  Datacadastro { get; set; }
    public DateTime Datanascimento { get; set; }
    public string Cep { get; set; }
    public string Endereco { get; set; }
    public string Numero { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public int Devendo { get; set; }
}
}