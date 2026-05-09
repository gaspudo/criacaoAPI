# ExoApi

REST API desenvolvida com **ASP.NET Core** e **Entity Framework Core**, utilizando **MySQL** como banco de dados. O projeto implementa o padrão Repository para gerenciamento de projetos e usuários.

## Tecnologias

- [.NET 10](https://dotnet.microsoft.com/)
- ASP.NET Core Web API
- Entity Framework Core 10
- Pomelo.EntityFrameworkCore.MySql 9
- MySQL

## Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- MySQL Server (local ou remoto)

## Configuração

1. Clone o repositório:
   ```bash
   git clone https://github.com/gaspudo/criacaoAPI.git
   cd criacaoAPI
   ```

2. Crie o banco de dados executando o script SQL:
   ```bash
   mysql -u root -p < script.sql
   ```

3. Configure a connection string em `appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "ExoApiDatabase": "Server=localhost;Database=db_exoapi;User=root;Password=SUA_SENHA;"
     }
   }
   ```

4. Restaure as dependências e execute:
   ```bash
   dotnet restore
   dotnet run
   ```

## Estrutura do Projeto

```
ExoApi/
├── Contexts/          # DbContext do EF Core
├── Controllers/       # Endpoints da API
├── Models/            # Entidades do domínio
├── Repositories/      # Padrão Repository (ex: ProjetoRepository)
├── script.sql         # Script de criação do banco de dados
└── Program.cs         # Configuração da aplicação
```

## Banco de Dados

O banco `db_exoapi` contém duas tabelas:

**tb_projetos**
| Coluna | Tipo | Descrição |
|---|---|---|
| cd_projeto | INT (PK) | Identificador |
| nm_projeto | VARCHAR(150) | Nome do projeto |
| nm_area | VARCHAR(150) | Área do projeto |
| fl_status | BOOLEAN | Status ativo/inativo |

**tb_usuarios**
| Coluna | Tipo | Descrição |
|---|---|---|
| cd_usuarios | INT (PK) | Identificador |
| ds_email | VARCHAR(255) | E-mail (único) |
| ds_senha | VARCHAR(120) | Senha |
