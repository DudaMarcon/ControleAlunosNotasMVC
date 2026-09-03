# 📚 Controle de Alunos e Notas

Sistema web desenvolvido para realizar o cadastro de alunos, cadastro de notas e consulta do boletim.

O projeto foi desenvolvido utilizando **C#**, **ASP.NET Core MVC**, **Entity Framework Core** e **SQLite**.

---

## 👥 Integrantes

- 👤 Maria Eduarda Silvestre Marcon
- 👤 Felipe Drigo Binatto
- 👤 Vinicius Drigo Binatto
- 👤 Isabela Stetz Tavernaro Camargo

**Turma:** 2°DS-AMS

---

## 🎯 Sobre o Projeto

O **Controle de Alunos e Notas** é um sistema desenvolvido para facilitar o gerenciamento das informações de alunos e suas respectivas notas.

O sistema permite cadastrar alunos, registrar notas por disciplina e consultar o boletim de cada aluno. As informações são armazenadas em um banco de dados SQLite.

### ✨ Funcionalidades

- 👨‍🎓 Cadastro de alunos
- 📝 Cadastro de notas
- 📋 Listagem de alunos
- 📊 Consulta do boletim
- 🧮 Cálculo automático da média
- ✅ Identificação da situação do aluno
- 💾 Armazenamento das informações em banco de dados

---

## 🛠️ Tecnologias Utilizadas

- **C#** — Linguagem de programação
- **ASP.NET Core MVC** — Desenvolvimento da aplicação web
- **Entity Framework Core** — Comunicação com o banco de dados
- **SQLite** — Banco de dados
- **HTML e CSS** — Estrutura e estilização das páginas
- **Bootstrap** — Interface e componentes visuais
- **Git e GitHub** — Controle de versão

---

## 🗂️ Estrutura do Projeto

```text
ControleAlunosNotasMVC/
│
├── Controllers/
│   ├── AlunoController.cs
│   └── HomeController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Migrations/
│   ├── CriarBanco
│   └── CriarNotas
│
├── Models/
│   ├── Aluno.cs
│   ├── Notas.cs
│   └── ErrorViewModel.cs
│
├── ViewModels/
│   ├── CriarAlunoViewModel.cs
│   └── CriarNotaViewModel.cs
│
├── Views/
│   ├── Aluno/
│   │   ├── Index.cshtml
│   │   ├── Criar.cshtml
│   │   ├── CriarNota.cshtml
│   │   └── Detalhes.cshtml
│   │
│   ├── Home/
│   └── Shared/
│
├── wwwroot/
│
├── alunos.db
├── Program.cs
├── appsettings.json
└── README.md
```

---

# 🚀 Como Executar o Projeto

Para executar o projeto em outro computador, siga os passos abaixo.

## 📋 Pré-requisitos

Antes de começar, é necessário ter instalado:

- .NET SDK
- Git
- Visual Studio ou Visual Studio Code

---

## 1️⃣ Clonar o repositório

Abra o terminal e execute:

```bash
git clone https://github.com/DudaMarcon/ControleAlunosNotasMVC.git
```

---

## 2️⃣ Acessar a pasta do projeto

```bash
cd ControleAlunosNotasMVC
```

---

## 3️⃣ Restaurar as dependências

Execute:

```bash
dotnet restore
```

Esse comando restaura as dependências necessárias para executar o projeto.

---

## 4️⃣ Configuração do banco de dados

O projeto utiliza **SQLite** para armazenar as informações.

O banco de dados utilizado é o arquivo:

```text
alunos.db
```

A conexão está configurada no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Data Source=alunos.db"
}
```

---

## 5️⃣ Atualizar o banco de dados

Caso seja necessário criar ou atualizar o banco de dados utilizando as migrations, execute:

```bash
dotnet ef database update
```

As migrations são responsáveis por criar e atualizar a estrutura das tabelas utilizadas pelo sistema.

---

## 6️⃣ Executar o projeto

Para iniciar a aplicação, execute:

```bash
dotnet run
```

Após executar o comando, o terminal irá informar o endereço local da aplicação.

Abra o endereço informado no navegador para acessar o sistema.

---

# 👨‍🎓 Cadastro de Alunos

O sistema permite cadastrar um aluno informando:

- Nome
- Turma
- Matrícula
- Status
- Curso

Após o cadastro, os dados são armazenados no banco de dados.

---

# 📝 Cadastro de Notas

Também é possível cadastrar notas para os alunos já registrados.

Para cada disciplina são informados:

- Aluno
- Disciplina
- Nota 1
- Nota 2

A média é calculada automaticamente pelo sistema:

```text
Média = (Nota 1 + Nota 2) / 2
```

A situação do aluno é definida de acordo com a média:

```text
Média ≥ 6 → Aprovado
Média < 6 → Reprovado
```

---

# 📊 Boletim

Na página de detalhes do aluno é possível consultar suas notas e sua situação em cada disciplina.

| Informação | Descrição |
|---|---|
| Disciplina | Nome da disciplina |
| Nota 1 | Primeira nota |
| Nota 2 | Segunda nota |
| Média | Média das duas notas |
| Situação | Aprovado ou Reprovado |

---

# 🗄️ Banco de Dados

O projeto utiliza **SQLite** para armazenar os dados.

### 👨‍🎓 Tabela Alunos

Armazena as informações:

- ID
- Nome
- Turma
- Matrícula
- Status
- Curso

### 📚 Tabela Notas

Armazena:

- ID
- AlunoId
- Disciplina
- Nota 1
- Nota 2

A tabela **Notas** possui uma relação com a tabela **Alunos** através do campo `AlunoId`.

---

# 🔄 Funcionamento do Sistema

O fluxo principal do sistema funciona da seguinte forma:

```text
Usuário
   ↓
Formulário
   ↓
ViewModel
   ↓
Controller
   ↓
Model
   ↓
Entity Framework Core
   ↓
SQLite
```

Dessa forma, as informações preenchidas pelo usuário são processadas pela aplicação e armazenadas no banco de dados.

---

# 🎓 Objetivo do Projeto

O projeto foi desenvolvido com finalidade acadêmica, buscando colocar em prática conhecimentos sobre:

- C#
- ASP.NET Core MVC
- Entity Framework Core
- Banco de dados
- CRUD
- Models
- ViewModels
- Controllers
- Views
- Migrations
- Git e GitHub

---

## 📌 Projeto Acadêmico

**Curso:** Desenvolvimento de Sistemas  
**Turma:** 2°DS-AMS

> Projeto desenvolvido para fins educacionais.
