namespace ApiCrud.models;

// MAPEANDO AS ENTIDADES 
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Valor { get; set; }
    public int Estoque { get; set; }
    
    // MÉTODO CONSTRUTOR 
    public Produto(int id, string nome, double valor, int estoque)
    {
        Id = id;
        Nome = nome;
        Valor = valor;
        Estoque = estoque;
    }
}