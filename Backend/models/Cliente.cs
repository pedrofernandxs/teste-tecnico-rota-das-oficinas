﻿namespace ApiCrud.models;

// MAPEANDO AS ENTIDADES 
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    
    // MÉTODO CONSTRUTOR
    public Cliente(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
}