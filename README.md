# ✈️ Jornada Milhas

Aplicação de console em C# para gerenciar **ofertas de viagem**: cadastro, listagem e validação de rotas, períodos e preços.

Projeto de estudo voltado para a prática de **testes unitários com xUnit**. Ele parte do código-base do curso da Alura ([repositório original](https://github.com/alura-cursos/3639-csharptestes-jornadamilhas-curso1)), migrado para o **.NET 10**.

---

## 🧰 Tecnologias

| Item | Versão |
|---|---|
| .NET SDK | 10.0 (fixado em [`global.json`](global.json)) |
| C# | 14 |
| Entity Framework Core (SQL Server) | 10.0.15 (referenciado, mas ainda não utilizado no código) |

Recursos do projeto habilitados no `.csproj`: `Nullable` e `ImplicitUsings`.

---

## 📁 Estrutura

```
JornadaMilhas/
├── JornadaMilhas.sln
├── global.json
└── src/
    └── JornadaMilhasV1/
        ├── Program.cs                      # Menu do console (ponto de entrada)
        ├── Gerencidor/
        │   └── GerenciadorDeOfertas.cs     # Cadastro, carga inicial e listagem de ofertas
        ├── Modelos/
        │   ├── OfertaViagem.cs             # Oferta = Rota + Período + Preço
        │   ├── Rota.cs                     # Origem e destino
        │   ├── Periodo.cs                  # Datas de ida e volta
        │   └── ValidaInformacoes.cs        # (fora da compilação — ver .csproj)
        └── Validador/
            ├── IValidavel.cs               # Contrato de validação e coleção de erros
            └── Valida.cs                   # Classe base abstrata (EhValido / Erros)
```

---

## ✅ Regras de validação

As entidades herdam de `Valida` e registram erros em vez de lançar exceções. Use `EhValido` e `Erros.Sumario` para consultar o resultado.

| Entidade | Regra |
|---|---|
| `Periodo` | A data de ida não pode ser posterior à data de volta. |
| `Rota` | Origem e destino não podem ser nulos ou vazios. |
| `OfertaViagem` | Precisa ter rota e período válidos, e o preço deve ser **maior que zero**. |

---

## ▶️ Como executar

**Pré-requisito:** [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0). Para conferir a versão instalada, use `dotnet --list-sdks`.

### Linha de comando

```bash
dotnet restore
dotnet build
dotnet run --project src/JornadaMilhasV1/JornadaMilhas.csproj
```

### Visual Studio 2026

Abra o `JornadaMilhas.sln` e pressione **F5**.

### JetBrains Rider

Abra o `JornadaMilhas.sln` e execute a configuração **JornadaMilhas**.

### VS Code

1. Instale a extensão **C# Dev Kit** (`ms-dotnettools.csdevkit`).
2. Abra a pasta raiz do projeto.
3. Pressione **F5** e escolha **C#** como depurador.

> ⚠️ O menu usa `Console.ReadKey()`, então execute o app em um **terminal interativo**. Com entrada redirecionada (pipe ou script), ele lança `InvalidOperationException`.

### Menu

```
1. Cadastrar Ofertas
2. Mostrar Todas as Ofertas
3. Exibir maiores descontos      (ainda não implementado)
4. Sair
```

Ao iniciar, a aplicação carrega três ofertas de exemplo.

---

## 🔀 Repositórios remotos

| Remoto | Destino | Uso |
|---|---|---|
| `origin` | este repositório | `git push` / `git pull` |
| `upstream` | repositório do curso | somente leitura (`git fetch upstream`), com push desativado |

Para trazer atualizações do curso:

```bash
git fetch upstream
git merge upstream/main
```

---

## 🗺️ Próximos passos

- [ ] Criar o projeto de testes com xUnit (`dotnet new xunit`)
- [ ] Implementar a opção "Exibir maiores descontos"
- [ ] Corrigir os avisos de nulidade (CS8600/CS8604) em `GerenciadorDeOfertas`
- [ ] Persistir as ofertas com EF Core
