# Operações com Conjuntos – WPF com C# e XAML

Projeto desenvolvido com **WPF (.NET Framework)** utilizando **C#** e **XAML**, com o objetivo de realizar **operações matemáticas entre conjuntos** de forma visual e interativa.

Este projeto foi elaborado como parte da disciplina **Qualidade e Teste de Software (QTS)**.

---

## Sobre o projeto / Funcionalidades

- Inserção e manipulação de elementos nos conjuntos A e B
- Operações matemáticas:
  - União (`A ∪ B`)
  - Interseção (`A ∩ B`)
  - Diferença A - B (`A − B`)
  - Diferença B - A (`B − A`)
- Remoção de elementos, limpeza total e geração automática de números
- Testes funcionais com barra de progresso e execução assíncrona (async/await)

---

## Arquitetura MVVM

### 📁 Model

- `Conjunto.cs`:  
  Define a lógica de manipulação dos conjuntos, como adicionar elementos, definir limite de itens, remover, limpar e gerar números aleatórios.

- `Operacoes.cs`:  
  Contém os métodos que realizam as operações matemáticas entre os conjuntos (`Uniao`, `Interseccao`, `DiferencaAB`, `DiferencaBA`) usando `System.Linq`.

- `Testes.cs`:  
  Executa **testes funcionais** da aplicação:
  - Valida adição e remoção de elementos
  - Garante que não é possível adicionar duplicados ou strings inválidas
  - Testa todas as operações matemáticas com conjuntos de exemplo
  - Os testes usam uma classe interna `ConjuntoFake` para evitar dependência da interface gráfica
  - Resultados são exibidos com `await Task.Delay()` para simular progresso visível

---

### 🖼️ View

- `MainWindow.xaml`:  
  Interface gráfica, construída com XAML, contendo inputs, botões de operação, lista visual dos conjuntos e barra de progresso para testes.

- `MainWindow.xaml.cs`:  
  Código responsável por conectar a interface com os métodos do `Model`. Inclui:
  - Validação dos conjuntos antes das operações
  - Execução de cada operação com exibição ordenada dos resultados
  - Comandos de interface como adicionar, remover e limpar elementos
  - Botão que executa os testes funcionais com exibição do progresso
 
---

## Tecnologias Utilizadas

- **WPF (Windows Presentation Foundation)**  
- **.NET Framework**
- **C#**  
- **XAML**  
- Biblioteca: `using System.Linq;`

> A biblioteca `System.Linq` foi essencial para manipulação e comparação de conjuntos de maneira eficiente e concisa.

---

## 👥 Equipe

- 💻 Desenvolvimento e testes: **[Ivan Henrique](https://github.com/Iwanhrq)**  
- 💻 Desenvolvimento e documentação: **[Mariana Araripe](https://github.com/marianaararipe)**

---

## Aprendizados

Durante o desenvolvimento deste projeto, aprendemos a:

- Criar interfaces gráficas com WPF e XAML
- Aplicar LINQ para manipulação de dados em C#
- Escrever testes funcionais para validação de lógica
- Trabalhar com entrada de dados e exibição de resultados de forma dinâmica
- Utilizar boas práticas de codificação e separação de responsabilidades

---

## Estrutura do Projeto

```bash
/
├── Model/
│   ├── Conjunto.cs        # Manipulação de dados dos conjuntos
│   ├── Operacoes.cs       # Métodos de união, interseção e diferenças
│   └── Testes.cs          # Testes funcionais da aplicação
│
├── MainWindow.xaml        # Interface gráfica (View)
├── MainWindow.xaml.cs     # Lógica de interação com o usuário
│
├── bin/                   # Saída de compilação
└── obj/                   # Arquivos temporários do Visual Studio
