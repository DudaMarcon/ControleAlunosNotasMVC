# 📚 Controle de Alunos e Notas

Sistema desenvolvido para realizar o **cadastro de alunos e suas respectivas notas**, permitindo também consultar o boletim de cada aluno.

O projeto foi desenvolvido utilizando **ASP.NET Core MVC**, **C#**, **Entity Framework Core** e **SQLite**, com o objetivo de colocar em prática os conhecimentos adquiridos durante as aulas.

---

## 👥 Integrantes

- 👤 Maria Eduarda Silvestre Marcon
- 👤 Felipe Drigo Binatto
- 👤 Vinicius Drigo Binatto
- 👤 Isabela Stetz Tavernaro Camargo 

**Turma:** 2°DS-AMS

---

## 🎯 Sobre o Projeto

O **Controle de Alunos e Notas** é um sistema web que permite cadastrar alunos e registrar suas notas.

A aplicação possui um banco de dados para armazenar as informações, substituindo o armazenamento que anteriormente era feito apenas em memória.

### Principais funcionalidades:

- 👨‍🎓 Cadastro de alunos
- 📝 Cadastro de notas
- 📋 Listagem de alunos
- 📊 Visualização do boletim
- 🧮 Cálculo automático da média
- ✅ Identificação da situação do aluno
- 💾 Armazenamento das informações em banco de dados

---

## 🛠️ Tecnologias utilizadas

| Tecnologia | Utilização |
|---|---|
| 💻 C# | Linguagem de programação |
| 🌐 ASP.NET Core MVC | Desenvolvimento da aplicação web |
| 🗄️ Entity Framework Core | Comunicação com o banco de dados |
| 🪶 SQLite | Banco de dados |
| 🎨 HTML / CSS | Estrutura e aparência das páginas |
| 🅱️ Bootstrap | Estilização da interface |
| 🔧 Git / GitHub | Controle de versão e armazenamento do projeto |

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
