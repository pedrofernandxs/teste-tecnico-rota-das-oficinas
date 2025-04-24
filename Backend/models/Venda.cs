namespace ApiCrud.models;

// MAPEANDO AS ENTIDADES 
public class Venda
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataVenda { get; set; }
    public Cliente Cliente { get; set; }
    public ICollection<ItemVenda> Itens { get; set; }
    
    // MÉTODO CONSTRUTOR
    public Venda(int id, int clienteId, DateTime dataVenda, Cliente cliente, List<ItemVenda> itens)
    {
        Id = id;
        ClienteId = clienteId;
        DataVenda = dataVenda;
        Cliente = cliente;
        Itens = itens;
    }
}