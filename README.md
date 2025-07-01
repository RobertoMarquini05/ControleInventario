# 📦 InventarioAPI

API REST criada para controle de inventário de itens, com funcionalidades de cadastro, listagem, movimentação de estoque e gerenciamento de categorias.

> 🔧 Projeto pessoal desenvolvido com o objetivo de praticar os fundamentos aprendidos em cursos de C# e ASP.NET Core.

---

## 🚀 Tecnologias Utilizadas

- **.NET 8 / ASP.NET Core**
- **C#**
- **Arquitetura em camadas (Controllers, Services, Repositories)**
- **Persistência em arquivos JSON (sem banco de dados)**
- **API RESTful com suporte a CORS**
- **Front-end simples em HTML + CSS + JS**

---

## 🔗 Funcionalidades

| Rota                        | Método | Descrição                            |
|----------------------------|--------|--------------------------------------|
| `/api/itens`               | GET    | Listar todos os itens                |
| `/api/itens/{id}`          | GET    | Obter item por ID                    |
| `/api/itens`               | POST   | Criar um novo item                   |
| `/api/itens/{id}`          | PUT    | Atualizar item por ID               |
| `/api/itens/{id}`          | DELETE | Deletar item por ID                  |
| `/api/categorias`          | GET/POST/PUT/DELETE | Gerenciar categorias       |
| `/api/movimentacoes`       | GET/POST | Registrar e listar movimentações   |
| `/api/movimentacoes/item/{id}` | GET | Ver movimentações por item         |
| `/api/movimentacoes/tipo/{tipo}` | GET | Ver entradas ou saídas            |

---

## 🧪 Como rodar o projeto

1. **Clone o repositório**
```bash
git clone https://github.com/seu-usuario/InventarioAPI.git
cd InventarioAPI
```

2. **Execute o backend**
```bash
dotnet run
```

3. O backend estará disponível em:
```
http://localhost:5000
https://localhost:5001
```

4. **Abra o front-end**
- Navegue até a pasta `Frontend/`
- Abra o `index.html` com o navegador

---

## 📁 Estrutura simplificada do projeto

```
InventarioAPI/
├── Application/
├── Controllers/
├── Data/
├── Domain/
├── Frontend/
└── Program.cs
```

---

## 📚 Objetivos do Projeto

- Praticar arquitetura em camadas
- Entender a persistência de dados com arquivos JSON
- Criar uma API RESTful com ASP.NET Core
- Simular controle de estoque com movimentações

---

## 🧠 Futuras melhorias

- Implementar autenticação com JWT
- Usar banco de dados relacional (PostgreSQL ou SQL Server)
- Criar dashboard com gráficos
- Migrar front-end para React ou Blazor

---

## ⚠️ Aviso

Este projeto não é voltado para produção. O foco está em **aprendizado prático** e **experimentação** com ASP.NET Core, sem banco de dados real ou autenticação.---

## 📄 Autor

Desenvolvido por [Roberto Marquini](https://www.linkedin.com/in/roberto-marquini/)

© 2025 Roberto Marquini. Todos os direitos reservados.
