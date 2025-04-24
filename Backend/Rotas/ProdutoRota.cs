using ApiCrud.models;

namespace ApiCrud.Rotas;

// INSTANCIANDO UM PRODUTO DO TIPO PRODUTO HERDANDO SEUS ATRIBUTOS
public static class ProdutoRotas
{
    public static List<Produto> Produtos = new()
    {
        new Produto(id: 1, nome:"Teclado", valor: 100.99, estoque: 30),
        new Produto(id: 2, nome:"Mouse", valor: 70.99, estoque: 20),
        new Produto(id: 3, nome:"Monitor", valor: 850.99, estoque: 4),
        new Produto(id: 3, nome:"VideoGame", valor: 3000, estoque: 46)
    };
    
    // CRIANDO O ENDPOINT GET PARA OBTER OS PRODUTOS CADASTRADOS
    public static void MapProdutoRotas(this WebApplication app)
    {
        app.MapGet("/produtos", handler:() => Produtos);
        
        // CRIANDO O ENDPOINT GET PARA OBTER OS PRODUTOS CADASTRADOS FILTRADOS POR NOME
        app.MapGet("produtos/{nome}", (string nome) =>
            ProdutoRotas.Produtos.Find(x => x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
        );
        
        // CRIANDO O ENDPOINT GET PARA ALTERAR OS PRODUTOS CADASTRADOS FILTRADOS POR ID
        app.MapPut("produtos/{id}", (int id, Produto produtoAtualizado) =>
        {
            var produto = ProdutoRotas.Produtos.Find(x => x.Id == id);
            if (produto == null) return Results.NotFound();
            
            produto.Nome = produtoAtualizado.Nome;
            produto.Estoque = produtoAtualizado.Estoque;
            produto.Valor = produtoAtualizado.Valor;
            
            return Results.Ok(produto);
        });
        
        // CRIANDO O ENDPOINT DELETE PARA DELETRR OS PRODUTOS CADASTRADOS POR ID

        app.MapDelete("/produtos/{id}", (int id) =>
        {
            var produto = Produtos.Find(c => c.Id == id);
            if (produto is null) return Results.NotFound();

            Produtos.Remove(produto);
            return Results.NoContent();
        });
        
    }
}