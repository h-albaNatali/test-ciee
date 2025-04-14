# 🐾 Zoo Manager

Sistema Web de Gerenciamento de Animais e Cuidados para Zoológicos — desenvolvido como parte de um desafio técnico.

![Docker](https://img.shields.io/badge/Docker-ready-blue)
![.NET](https://img.shields.io/badge/.NET%207-API-blueviolet)
![Angular](https://img.shields.io/badge/Angular-17-red)
![Status](https://img.shields.io/badge/status-finalizado-brightgreen)

## 📋 Descrição

Este sistema permite o cadastro, edição, listagem e remoção de **animais** e seus **cuidados** associados, com um relacionamento muitos-para-muitos entre eles. Conta também com autenticação via JWT, proteções de rota, e interface amigável feita em Angular.

## 🚀 Tecnologias Utilizadas

### Backend

- ASP.NET Core 7
- Entity Framework Core
- SQL Server
- AutoMapper
- JWT (JSON Web Token)
- Swagger
- Docker

### Frontend

- Angular 17
- Standalone Components
- Angular Router & HTTPClient
- Interceptors
- SCSS
- Toasts para feedback visual

## 📦 Como Rodar o Projeto

### Pré-requisitos

- Docker Desktop com suporte a WSL2 habilitado
- Node.js v18+ (para o frontend)
- Git

### Clonando o repositório

```bash
git clone git@github.com:h-albaNatali/cat-records-api.git
cd zoo-manager
```

### Subindo com Docker (API + banco)

```bash
cd backend
docker compose up --build
```

- Acesse a API: [http://localhost:5000/swagger](http://localhost:5000/swagger)

### Aplicando as migrations

```bash
docker compose run --rm ef-migrator
```

### Subindo o Frontend separadamente

```bash
cd frontend
npm install
ng serve
```

- Acesse o frontend: [http://localhost:4200](http://localhost:4200)

---

## ✅ Funcionalidades Implementadas

### 🦁 Animais

- [x] Listar animais
- [x] Cadastrar novo animal
- [x] Editar animal existente
- [x] Remover animal
- [x] Associações com cuidados (muitos-para-muitos)

Campos obrigatórios:
- Nome
- Descrição
- Data de nascimento
- Espécie
- Habitat
- País de origem

### 💉 Cuidados

- [x] Listar cuidados
- [x] Cadastrar cuidado
- [x] Editar cuidado
- [x] Remover cuidado
- [x] Associar/desassociar cuidados de um animal (soft-delete da relação)

Campos obrigatórios:
- Nome
- Descrição
- Frequência

### 🔐 Autenticação

- [x] Login via JWT
- [x] Logout e expiração de token
- [x] Proteção de rotas no frontend
- [x] Interceptor para envio automático do token

---

## 🌟 Diferenciais (Extras)

| Diferencial | Detalhes |
|-------------|----------|
| **🛠️ Docker + SQL Server + Compose** | Ambiente isolado e realista com SQL rodando em container |
| **🔐 Autenticação JWT completa** | Com login, cadastro, proteção de rotas e interceptor Angular |
| **📌 Relação muitos-para-muitos** | Mapeada corretamente com AutoMapper + DTOs + frontend funcional |
| **💖 Frontend Standalone Angular** | Uso de `standalone components`, `Router`, `Interceptor`, `Guards` |
| **🚀 UX com feedback visual** | Toasts de sucesso, erro, botões com loading, validação nos forms |
| **📆 Estrutura de serviços limpa** | `animal.service.ts`, `care.service.ts`, `auth.service.ts` separados |

---

## ❌ Funcionalidades não implementadas (por escolha estratégica)

- Dashboard com gráficos (tempo de entrega não justificava)
- Filtros avançados (idade, país, habitat)
- Alertas de cuidados pendentes
- Testes automatizados (foco em entrega funcional)

---

## 👷️ Autor

Desenvolvido por **Henrique** — como parte de um desafio técnico para uma vaga de desenvolvedor .NET + Angular.

---

## 📌 Licença

Este projeto está sob a licença MIT.

