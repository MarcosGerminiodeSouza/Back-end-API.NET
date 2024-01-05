# API .NET usando Entity Framework para MySQL

API de livros em **C#** do tipo **WebAPI ASP.NET** que armazena a entidades relacionadas banco de dados **MySQL**.

- API
- Code First
- Entity Framework
    1. dotnet-ef migrations add marcos_livraria_webapi
    2. dotnet-ef database update
- Armazenamento em Banco de Dados MySQL
- Relacionamento de Entre Objetos
- Virtual
- Collection
- Assinaturas
- Migrations
- Lazy Load
- CRUD
    1. Create = Post
    2. Read = Get
    3. Update = Put
    4. Delete = Delete

## VS Code - LivrariaAPI

- **Comando CLI: dotnet watch run** =  [Swagger](http://localhost:5111/swagger/index.html)
- **.NET Web API - Version 7.0**

**References - pakeges**:

- Microsoft.AspNetCore.OpenApi 7.0.13
- Microsoft.EntityFrameworkCore.Design 7.0.13
- Microsoft.EntityFrameworkCore.Tools 7.0.13
- Pomelo.EntityFrameworkCore.MySql 7.0.0
- Swashbuckle.AspNetCore 6.5.0
