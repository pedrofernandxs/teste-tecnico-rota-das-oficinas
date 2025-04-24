using ApiCrud.models;
using static ApiCrud.Rotas.ClienteRotas;
using static ApiCrud.Rotas.ProdutoRotas;

namespace ApiCrud.Rotas;

// INSTANCIANDO UMA VENDA DO TIPO VENDA PARA DEFINIR AS VENDAS REALIZADAS NO ECOMMERCE
public static class VendaRota
{
    public static List<Venda> Vendas;

    // ARMAZENANDO AS INFORMAÇÕES DO TIPO CLIENTE/PRODUTOS EM VARIAVEIS Cliente0 & Produtos0

    static VendaRota()
    {
        var cliente0 = Clientes.ElementAtOrDefault(0);
        var cliente1 = Clientes.ElementAtOrDefault(1);
        var cliente2 = Clientes.ElementAtOrDefault(2);

        var produto0 = Produtos.ElementAtOrDefault(0);
        var produto1 = Produtos.ElementAtOrDefault(1);
        var produto2 = Produtos.ElementAtOrDefault(2);
        var produto3 = Produtos.ElementAtOrDefault(3);

        // INSTANCIANDO UMA VENDA COM SEUS ATRIBUTOS E UTILIZANDO A CLASSE ItemVenda, PARA DEFINIR O PRODUTO VENDIDO COM A QUANTIDADE

        Vendas = new List<Venda?>
        {
            cliente0 != null && produto0 != null && produto1 != null ?
            new Venda(
                id: 1,
                clienteId: cliente0.Id,
                dataVenda: DateTime.Now,
                cliente: cliente0,
                itens: new List<ItemVenda>
                {
                    new ItemVenda { Produto = produto0, Quantidade = 2 },
                    new ItemVenda { Produto = produto1, Quantidade = 1 }
                }
            ) : null,

            cliente1 != null && produto2 != null ?
            new Venda(
                id: 2,
                clienteId: cliente1.Id,
                dataVenda: DateTime.Now,
                cliente: cliente1,
                itens: new List<ItemVenda>
                {
                    new ItemVenda { Produto = produto2, Quantidade = 4 }
                }
            ) : null,

            cliente2 != null && produto3 != null ?
            new Venda(
                id: 3,
                clienteId: cliente2.Id,
                dataVenda: DateTime.Now,
                cliente: cliente2,
                itens: new List<ItemVenda>
                {
                    new ItemVenda { Produto = produto3, Quantidade = 6 }
                }
            ) : null
        }.Where(v => v != null).Cast<Venda>().ToList();
    }

    // ENDPOINTS DO TIPO GET PARA OBTER TODAS AS VENDAS REALIZADAS
    public static void MapVendasRotas(this WebApplication app)
    {
        app.MapGet("/vendas", () => Vendas);

        // ENDPOINTS DO TIPO GET PARA OBTER TODAS AS VENDAS REALIZADAS POR ID
        app.MapGet("/vendas/{id}", (int id) =>
            Vendas.Find(x => x.Id == id)
        );
        
        // ENDPOINTS DO TIPO GET PARA OBTER TODAS AS VENDAS REALIZADAS EM DETERMINADO PERIODO E DEFINIR O TOTAL DO LUCRO DAS VENDAS E OS ITENS VENDIDOS
        app.MapGet("/vendas/analise", (DateTime dataInicio, DateTime dataFim) =>
        {
            var vendasPeriodo = Vendas
                .Where(v => v.DataVenda.Date >= dataInicio.Date && v.DataVenda.Date <= dataFim.Date)
                .ToList();

            var quantidadeVendas = vendasPeriodo.Count;

            double rendaTotal = 0;
            var rendaPorProduto = new Dictionary<string, double>();

            foreach (var venda in vendasPeriodo)
            {
                foreach (var item in venda.Itens)
                {
                    double valorProduto = item.Produto.Valor * item.Quantidade;
                    rendaTotal += valorProduto;

                    if (rendaPorProduto.ContainsKey(item.Produto.Nome))
                        rendaPorProduto[item.Produto.Nome] += valorProduto;
                    else
                        rendaPorProduto[item.Produto.Nome] = valorProduto;
                }
            }

            return Results.Ok(new
            {
                QuantidadeVendas = quantidadeVendas,
                RendaTotal = rendaTotal,
                RendaPorProduto = rendaPorProduto
            });
        });
    }
}
