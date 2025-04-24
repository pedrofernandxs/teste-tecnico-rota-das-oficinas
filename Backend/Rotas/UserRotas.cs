using ApiCrud.models;
using ApiCrud.Services;

namespace ApiCrud.Rotas;

// INSTANCIANDO UM USUÁRIO DO TIPO USUÁRIO PARA DEFINIR SEUS ATRIBUTOS DE ACESSO E PERMITIR/NEGAR ACESSO COM O TOKEN JWT
public static class UserRotas
{
    public static List<User> Users = new()
    {
        new User(id: 1, email: "admin@gmail.com", password: "admin123")
    };

    
    // CRIANDO O ENDPOINT POST PARA ENVIAR OS DADOS SE ACESSO PARA AUTENTIAÇÃO
    public static void MapUserRotas(this WebApplication app)
    {
        // ROTA POST QUE FAZ A VALIDAÇÃO DO USUÁRIO, SE ELE TERÁ PERMISSÃO DE ACESSO OU NÃO
        app.MapPost("/tokenAuth", (User userTryingToAccess, TokenService tokenService) =>
        {
            var allowedUser = UserRotas.Users
                .FirstOrDefault(u => u.Email == userTryingToAccess.Email && u.Password == userTryingToAccess.Password);

            if (allowedUser == null)
                return Results.Unauthorized();
            
            var token = tokenService.Generate(allowedUser);
            return Results.Json(new { token });

        });
        
    }
}