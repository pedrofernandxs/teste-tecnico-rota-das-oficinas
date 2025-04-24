using ApiCrud.models;

namespace ApiCrud.Rotas;


// INSTANCIANDO UM CLIENTE [CRIANDO UM CLIENTE A PARTIR DOS ATRIBUTOS DA SUA CLASSE]
public static class ClienteRotas
{
    public static List<Cliente> Clientes = new()
    {
        new Cliente(id: 1, nome:"Pedro", email: "pedrofernandxs@gmail.com"),
        new Cliente(id: 2, nome:"RH", email:"rh@gmail.com"),
        new Cliente(id: 3, nome:"RotaDasOficinas", email:"RotaDasOficinas@gmail.com")
    };
    
    // CRIANDO O ENDPOINT GET PARA ACESSAR TODOS OS CLIENTES CRIADOS
    public static void MapClienteRotas(this WebApplication app)
    {
        app.MapGet("/clientes", handler:() => Clientes);
        
        // CRIANDO O ENDPOINT GET PARA ACESSAR TODOS OS CLIENTES FILTRADOS POR NOME
        app.MapGet(pattern:"clientes/{nome}",
            handler:(string nome) => Clientes.Find(x => x.Nome == nome));
        
        // CRIANDO O ENDPOINT POST PARA ATUALIZAR INFORMAÇÕES DO CLIENTE
        app.MapPut("/clientes/{id}", (int id, Cliente clienteAtualizado) =>
        {
            var cliente = Clientes.Find(c => c.Id == id);
            if (cliente is null) return Results.NotFound();

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Email = clienteAtualizado.Email;

            return Results.Ok(cliente);
        });
        
        // CRIANDO O ENDPOINT DELETE PARA DELETAR UM CLIENTE POR ID
        app.MapDelete("/clientes/{id}", (int id) =>
        {
            var cliente = Clientes.Find(c => c.Id == id);
            if (cliente is null) return Results.NotFound();

            Clientes.Remove(cliente);
            return Results.NoContent();
        });
        
    }
}