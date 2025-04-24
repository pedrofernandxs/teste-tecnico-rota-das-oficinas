namespace ApiCrud.models;

// MAPEANDO AS ENTIDADES 
public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    
    // MÉTODO CONSTRUTOR
    public User(int id, string email, string password)
    {
        Id = id;
        Email = email;
        Password = password;
    }
}
