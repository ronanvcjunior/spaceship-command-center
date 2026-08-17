# spaceship-command-center

Central de comandos de uma nave espacial simulada no console. Fiz esse projeto como resolução do desafio técnico do processo seletivo do LabTIME/UFG. A ideia era pegar as demandas do briefing e resolver cada uma com um padrão de projeto que fizesse sentido pra ela, sem aplicar padrões que não se encaixassem de verdade no problema.

Separei as decisões por ticket, na ordem em que fui implementando (dá pra acompanhar também pelo histórico de commits).

## Como rodar

Precisa do .NET 8 SDK instalado ([aqui](https://dotnet.microsoft.com/download/dotnet/8.0) se não tiver).

```bash
git clone https://github.com/ronanvcjunior/spaceship-command-center.git
cd spaceship-command-center
dotnet run
```

Isso abre um console esperando comandos. É só digitar `<comando> <argumento>` e dar enter.

| Comando | Uso | O que faz |
|---|---|---|
| `tomar_dano` | `tomar_dano <valor>` | Aplica dano ao núcleo |
| `trocar_funcao` | `trocar_funcao <funcao>` | Define a função do tripulante (`ocioso`, `mecanico`, `artilheiro`) |
| `trabalhar` | `trabalhar` | Manda o tripulante executar a tarefa da função atual |
| `equipar_arma` | `equipar_arma <arma>` | Equipa uma arma na nave (`desacoplado`, `laser`, `misseis`) |
| `adicionar_modificador` | `adicionar_modificador <modificador>` | Coloca um modificador na arma atual (`fogo`, `perfuracao`) |
| `atirar` | `atirar` | Dispara com a arma equipada |
| `help` | `help` | Lista todos os comandos disponíveis com suas descrições |
| `sair` | `sair` | Encerra a aplicação |

Um exemplo de sessão:

```
> equipar_arma laser
[Nave] Laser Contínuo equipado(a) com sucesso.
> adicionar_modificador fogo
[Nave] Laser Contínuo Fogo equipado(a) com sucesso.
> atirar
Rajada contínua de laser.
[causando Dano de Fogo continuo!]
> tomar_dano 90
[Núcleo] Energia atual: 10%.
[Núcleo] *** ESTADO CRÍTICO DETECTADO! (10%) ***
[Escudo] Redirecionando foco de defesa para o setor dianteiro!
[Iluminação] Luzes principais apagadas. Iluminação de emergência ativada.
[Painel] ATENÇÃO! Sinais de alerta exibidos no painel de navegação!
> help
Comandos disponíveis:
 - tomar_dano <valor> - Aplica dano ao núcleo.
 - trocar_funcao <funcao> - Define a função do tripulante (artilheiro, mecanico, ocioso).
 - trabalhar - Manda o tripulante executar a tarefa da função atual.
 - equipar_arma <arma> - Equipa uma arma (desacoplado, laser, misseis).
 - adicionar_modificador <modificador> - Adiciona um modificador à arma (fogo, perfuracao).
 - atirar - Dispara a arma equipada.
 - help - Mostra os comandos disponíveis.
 - sair - Encerra a aplicação.
> sair
Encerrando a central de comandos...
```

---

## Ticket 1: Núcleo da nave

O briefing pedia que a nave reagisse sozinha quando a energia do núcleo caísse pro nível crítico, e que vários sistemas diferentes (escudo, luz, painel) percebessem isso ao mesmo tempo, sem o núcleo precisar saber quem são eles.

Isso é praticamente a definição de Observer, então a escolha do padrão foi direta. A parte que exigiu mais reflexão foi como implementar.

Cheguei a cogitar criar uma interface `IObservadorCrise` pra deixar o padrão explícito no código. Mas o C# já resolve isso com `event`/`Action`, que na prática funciona como um Observer embutido na linguagem. Mantive a interface por um tempo, porém ela nunca era realmente usada: o `Nucleo` continuava disparando via evento, e a interface ficava apenas implementada pelas classes, sem cumprir função nenhuma. Removi depois (o commit `remove interface IObservadorCrise não utilizada` mostra essa mudança) porque não fazia sentido manter uma abstração que eu não usava de fato.

**Quem faz o quê:**
- `Nucleo` é o Subject. Dispara o evento `AoEntrarEmCrise` quando a energia atinge o nível crítico, dentro de `TomarDano()`.
- `SistemaEscudo`, `SistemaIluminacao` e `PainelNavegacao` são os observers, cada um com um método `ReagirACrise()`.
- A inscrição acontece em `Program.cs`, na forma `nucleo.AoEntrarEmCrise += escudo.ReagirACrise;`.

**Arquivos:** `src/Models/Nucleo.cs`, `src/Models/SistemaEscudo.cs`, `src/Models/SistemaIluminacao.cs`, `src/Models/PainelNavegacao.cs`.

---

## Ticket 2: Tripulante

Esse foi o ticket em que mais reconsiderei a abordagem inicial. O tripulante precisa assumir funções diferentes (ocioso, mecânico, artilheiro), e cada função executa uma tarefa diferente quando ele "trabalha".

De início, pensei em usar State, já que o tripulante muda de comportamento conforme a função, o que lembra uma transição de estado. Comecei a implementar dessa forma. No entanto, percebi um problema no meio do caminho: no padrão State clássico, cada estado conhece para quais outros estados pode transicionar, com regras de transição embutidas. Aqui não existe nada disso, a troca de função é decidida externamente, por comando direto, sem nenhuma regra do tipo "de mecânico só pode virar artilheiro". Ou seja, o que eu realmente precisava era trocar o comportamento, não modelar uma máquina de estados.

Refatorei então para Strategy (commit `altera de State para Strategy e reorganiza estrutura`). A solução ficou mais simples e também mais fiel ao problema que o padrão se propõe a resolver.

**Quem faz o quê:**
- `IFuncaoTripulante` é a interface da estratégia, com o método `Trabalhar(Tripulante tripulante)`.
- `FuncaoOcioso`, `FuncaoMecanico` e `FuncaoArtilheiro` são as estratégias concretas.
- `Tripulante` é o contexto. Guarda a função atual em `_funcao` e delega a execução a ela quando `Trabalhar()` é chamado. A troca de função acontece por meio de `TrocarFuncao()`.
- `FuncaoTripulanteRegistro` traduz um nome (string) para a instância da estratégia correspondente, usado pelo comando de console para resolver qual função atribuir.

**Arquivos:** `src/Abstractions/IFuncaoTripulante.cs`, `src/Strategies/FuncaoOcioso.cs`, `src/Strategies/FuncaoMecanico.cs`, `src/Strategies/FuncaoArtilheiro.cs`, `src/Models/Tripulante.cs`, `src/Services/FuncaoTripulanteRegistro.cs`.

---

## Ticket 3: Armamento

Esse ticket tinha duas partes bem distintas, então implementei em duas etapas (commits `implementa sistema básico de arma` e, na sequência, `implementa modificadores com Decorator`).

**Parte 1, trocar de arma.** A nave precisa equipar laser ou mísseis, o que é essencialmente o mesmo problema do tripulante: comportamento intercambiável. Usei Strategy novamente, pelo mesmo raciocínio já validado no ticket anterior.

**Parte 2, empilhar modificadores.** Aqui o requisito era diferente: a arma equipada precisa poder receber efeitos extras (fogo, perfuração), e esses efeitos podem se acumular. Resolver isso com Strategy exigiria uma classe para cada combinação possível (`ArmaLaserComFogo`, `ArmaLaserComFogoEPerfuracao`, e assim por diante), o que não escala bem. O Decorator resolve exatamente esse tipo de problema: cada modificador envolve a arma atual e adiciona um comportamento pontual ao `Atirar()`, sem precisar saber o que mais já foi aplicado antes dele.

**Quem faz o quê:**
- `IArma` é a interface comum, usada tanto pelas armas base (Strategy) quanto pelos modificadores (Decorator), com `Nome` e `Atirar()`.
- `ArmaLaser`, `ArmaMisseis` e `ArmaVazio` são as armas base. A `ArmaVazio` funciona como um Null Object, existe para a nave não começar com `Arma` nula, evitando checagens de nulo em outros pontos do código.
- `ModificadorArma` é o decorator base (abstrato). Guarda a arma decorada em `_arma` e, por padrão, apenas repassa a chamada de `Atirar()`.
- `ModificadorFogo` e `ModificadorPerfuracao` são os decorators concretos. Chamam `base.Atirar()` e adicionam o efeito correspondente em seguida.
- `Nave` guarda o que estiver equipado (uma arma base ou uma pilha de decorators) na propriedade `Arma`.
- `ArmaRegistro` e `ModificadorRegistro` cumprem o mesmo papel de tradução nome/instância do registro usado no ticket 2. O `ModificadorRegistro` guarda `Func<IArma, ModificadorArma>` porque um decorator depende da arma atual para ser construído, por isso o uso de fábricas em vez de instâncias prontas.

**Arquivos:** `src/Abstractions/IArma.cs`, `src/Abstractions/ModificadorArma.cs`, `src/Strategies/ArmaLaser.cs`, `src/Strategies/ArmaMisseis.cs`, `src/Strategies/ArmaVazio.cs`, `src/Decorators/ModificadorFogo.cs`, `src/Decorators/ModificadorPerfuracao.cs`, `src/Models/Nave.cs`, `src/Services/ArmaRegistro.cs`, `src/Services/ModificadorRegistro.cs`.

---

## O console interativo

Essa parte não corresponde a um ticket específico, é a estrutura que gerencia o loop principal do jogo e conecta todos os outros mecanismos (foi o segundo commit do projeto, logo após o núcleo, já que era necessário ter o console funcionando antes de testar o restante).

O requisito do desafio era que o console ficasse aguardando comandos indefinidamente, interpretando cada entrada digitada em tempo real. Isso significa que, a cada novo comando adicionado ao projeto (`tomar_dano`, `trocar_funcao`, `equipar_arma`, e assim por diante), o loop precisaria de alguma forma decidir qual ação executar. A abordagem mais direta seria uma cadeia de `if/else` ou um `switch/case` comparando o nome digitado com cada comando conhecido, mas isso criaria um ponto único que cresce a cada novo comando e que precisa ser alterado toda vez que uma funcionalidade nova é adicionada.

Usei Command pra resolver isso. Cada ação disponível foi encapsulada em uma classe própria, implementando `IComando`, e o `GerenciadorComandos` mantém um dicionário associando o nome do comando (string) a uma `DefinicaoComando`, que guarda tanto a instância do comando quanto a descrição usada pelo `help`. Não existe `if/else` nem `switch/case` em nenhum ponto do projeto para decidir qual ação executar: a resolução do comando é sempre feita por busca no dicionário (`_comandos.TryGetValue(nome, out var definicao)`), tanto aqui quanto nos registros dos outros tickets (`ArmaRegistro`, `FuncaoTripulanteRegistro`, `ModificadorRegistro`). Isso também significa que adicionar um novo comando não exige tocar no `GerenciadorComandos` nem no loop principal, só criar a classe do comando e registrá-la em `Program.cs`.

Os comandos `help` e `sair` seguem a mesma lógica dos demais, sem tratamento especial no loop:
- `ComandoAjuda` recebe o próprio `GerenciadorComandos` e lista as descrições de todos os comandos registrados nele, incluindo a si mesmo. Como a descrição é armazenada junto com o comando no momento do registro, o `help` nunca fica desatualizado em relação aos comandos disponíveis.
- `ComandoSair` recebe uma `Action` que altera a variável `executando`, declarada em `Program.cs`, para `false`. É essa variável que controla o loop principal.

Por causa disso, o `while (true)` original virou `while (executando)`. O loop em `Program.cs`, que é o coração do jogo, continua responsável só por ler a linha digitada, separar o nome do comando dos argumentos e repassar ao gerenciador, mas agora ele também respeita o pedido de encerramento vindo do próprio `ComandoSair`, sem precisar de um `break` ou de qualquer verificação adicional dentro do loop. Essa mudança está no commit `adiciona gerenciador de comandos, ajuda e saída`, que também adicionou os comentários por trecho ao `Program.cs` (inicialização do núcleo, registro das funções, registro das armas, registro dos modificadores, registro dos comandos, interface do console e loop principal), deixando mais fácil localizar onde cada mecanismo do jogo é montado.

**Arquivos:** `src/Abstractions/IComando.cs`, `src/Commands/*.cs`, `src/Invokers/GerenciadorComandos.cs`, `src/Invokers/DefinicaoComando.cs`, `Program.cs`.