# 🎮 GameUsersAPI

Uma API de registro e autenticação de usuários para jogos, construída com .NET 8, ASP.NET Core Identity e JWT.

Este projeto foi desenvolvido como parte da minha jornada em backend com .NET, focando em arquitetura limpa, boas práticas de API REST e segurança de autenticação moderna. A API permite que um cliente (como um *game client*) registre usuários, faça login e obtenha tokens JWT para acessar recursos protegidos.

---

## 🚀 Funcionalidades

- Registro de usuários com validação de dados
- Login com geração de JWT (JSON Web Token)
- Armazenamento seguro de senhas com ASP.NET Identity
- Validação de entrada com FluentValidation
- Tratamento centralizado de exceções
- Arquitetura desacoplada com casos de uso (UseCases)

---

## 🧠 Conceitos e tecnologias aplicados

Este projeto incorpora:

| Recurso | Tecnologias |
|---------|-------------|
| API REST | ASP.NET Core Web API |
| ORM | Entity Framework Core (EF Core) |
| Banco de Dados | SQLite |
| Validação de dados | FluentValidation |
| Autenticação | ASP.NET Core Identity |
| Autorização | JWT (JSON Web Tokens) |
| Tratamento de Erros | Exception Filters personalizados |
| Boas práticas | Arquitetura em camadas, DI, Clean Code |

---

## 📦 Requisitos

Antes de rodar o projeto, você precisa ter instalado:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Um editor de código, como **Visual Studio** ou **VS Code**

---

## 🧩 Estrutura do projeto

```

GameUsersAPI
├── GameUsers.API                ← Projeto principal da API
│   ├── Controllers              ← Endpoints da API
│   ├── Filters                  ← Filtros de exceção
│   ├── UseCase                  ← Casos de uso por funcionalidade
│   ├── Infraestructure          ← EF DbContext e configuração
│   ├── Models                   ← Entidades de domínio
│   └── Program.cs               ← Configuração de serviços e pipeline
├── GameUsers.Communication      ← DTOs de request/response
├── GameUsers.Exceptions         ← Exceções personalizadas
├── README.md                   ← Documentação
├── appsettings.json            ← Configurações (JWT, DB, etc.)
└── ...

````

---

## 🛠️ Como rodar localmente

1. Clone o repositório:

```bash
git clone https://github.com/Iclasth/GameUsersAPI.git
````

2. Entre na pasta do projeto:

```bash
cd GameUsersAPI/GameUsers.API
```

3. Instale as dependências e restaure pacotes:

```bash
dotnet restore
```

4. Crie as migrations e atualize o banco:

```bash
dotnet ef migrations add InitialIdentity
dotnet ef database update
```

5. Rode a API:

```bash
dotnet run
```

6. Acesse o Swagger para testar os endpoints:

```
https://localhost:5001/swagger
```

---

## 🔑 Endpoints principais

| Método | Endpoint             | Descrição                              |
| ------ | -------------------- | -------------------------------------- |
| POST   | `/api/auth/register` | Registra um novo usuário               |
| POST   | `/api/auth/login`    | Faz login e retorna um token JWT       |
| GET    | `/api/users`         | Exemplo de rota protegida (requer JWT) |

> A API possui autenticação JWT, portanto rotas protegidas exigem o cabeçalho:

```
Authorization: Bearer <seu_token_aqui>
```

---

## 🔒 Autenticação e Segurança

A API utiliza:

### ⚙️ **ASP.NET Core Identity**

* Gerencia usuários
* Armazena senhas de forma segura
* Integra com EF Core

### 🪪 **JWT (JSON Web Tokens)**

* Tokens assinado com chave secreta
* Permite rotas protegidas
* Stateless — o servidor **não guarda sessão**

💡 O token contém claims que representam o usuário logado.

---

## 🔄 Tratamento de Erros e Validações

* **FluentValidation**: valida os dados de entrada (DTOs)
* **ExceptionFilter**: converte exceções em respostas HTTP padronizadas
* Erros de validação retornam status `400 Bad Request`
* Regras de negócio retornam mensagens consistentes

---

## 🧪 Testes e Qualidade

Embora esse projeto não inclua testes automatizados ainda, você pode:

* Adicionar testes de unidade para UseCases
* Escrever testes de integração para rotas protegidas
* Configurar pipelines de CI/CD

---

## 💡 Próximos passos recomendados

Aqui vão ideias para evoluir o projeto:

* Adicionar Refresh Tokens
* Controlar Roles e Policies
* Implementar paginação e filtros avançados
* Subir em ambiente real (Azure / AWS / Railway / Render)

---

## 📎 Links úteis

* 🔗 Repositório: [https://github.com/Iclasth/GameUsersAPI](https://github.com/Iclasth/GameUsersAPI)
* 📍 Swagger (depois de rodar): `/swagger`

---

## 💬 Contribuições

Contribuições são bem-vindas!
Se você encontrou um bug ou tem uma sugestão, fique à vontade para abrir uma issue ou enviar um pull request 👍

---

## 🧠 Agradecimentos

Esse projeto foi um marco no meu aprendizado em APIs profissionais.
Agradeço a todos que acompanharam e colaboraram com feedbacks!

---

