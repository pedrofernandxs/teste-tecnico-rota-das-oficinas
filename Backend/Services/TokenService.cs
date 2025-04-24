using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ApiCrud.models;

namespace ApiCrud.Services;

public class TokenService
{
    public string Generate(User user)
    {
        // CRIA UMA INSTANCIA DO JwtSecurityTokenHandler
        var handler = new JwtSecurityTokenHandler();

        // CONVERTE A KEY QUE VEM DO ARQUIVO CONFIGURATION PARA UM ARRAY DE BYTES
        var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
        
        // PASSANDO OS PARAMETROS DA CREDENCIAL, A KEY E O ALGORITMO
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key), 
            SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = GenerateClaims(user),
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours(2),
        };
        
        // GERA UM TOKEN
        var token = handler.CreateToken(tokenDescriptor);
        
        // GERA UMA STRING TOKEN
        return handler.WriteToken(token);
        
    }

    public static ClaimsIdentity GenerateClaims(User user)
    {
        var ci = new ClaimsIdentity();
        ci.AddClaim(
            new Claim(ClaimTypes.Name, user.Email));
        
        return ci;
    }
    
}