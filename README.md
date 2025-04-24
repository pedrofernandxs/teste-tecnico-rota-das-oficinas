# 📦 Projeto Rota das Oficinas - Desafio Técnico API REST

Este é um sistema completo de gestão de clientes, produtos e vendas, desenvolvido com uma API REST em ASP.NET Core (.NET 8) e frontend em React.


## 🛠️ Tecnologias Utilizadas

### Backend (.NET 8)
- ASP.NET Core Web API
- JWT para autenticação
- Swagger para documentação
- Docker

### Frontend (React + Vite)
- ReactJS
- Axios para consumo da API
- React Router
- CSS modularizado

---

## ⚙️ Funcionalidades

### ✅ Backend (completo)
- Autenticação JWT com login e senha validados em `Services/TokenService.cs`
- CRUD completo de:
  - Clientes
  - Produtos
  - Vendas
- Rotas:
  - `GET`, `POST`, `PUT`, `DELETE` para todos os recursos
- Testável via:
  - [x] Swagger
  - [x] Postman
  - [x] Insomnia

### 💻 Frontend (parcial)
- Tela de **login de usuário**
  - Autenticação contra a API
  - Caso válido, redireciona automaticamente para `/home`
- Tela `/home`
  - Realiza `GETs` para:
    - Clientes
    - Produtos
    - Vendas

---

## 🔐 Credenciais de Acesso

As credenciais estão configuradas diretamente no backend:

📄 Local: `Services/TokenService.cs`

---

## ▶️ Como Executar

### Pré-requisitos

- [.NET SDK 8](https://dotnet.microsoft.com/en-us/download)
- Node.js 18+
- Docker (opcional para containers)

---

### Usando Docker

Na raiz do projeto `RO.TesteTécnico/`:

```bash
docker-compose up --build
