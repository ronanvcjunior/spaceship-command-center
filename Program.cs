using spaceship_command_center.src.Commands;
using spaceship_command_center.src.Decorators;
using spaceship_command_center.src.Invokers;
using spaceship_command_center.src.Models;
using spaceship_command_center.src.Services;
using spaceship_command_center.src.Strategies;

// ============================================================
// Inicialização do núcleo e dos sistemas que reagem à crise.
// ============================================================

var nucleo = new Nucleo(100, 20);
var escudo = new SistemaEscudo();
var iluminacao = new SistemaIluminacao();
var painel = new PainelNavegacao();

// Observer:
// O núcleo não conhece diretamente os sistemas que precisam
// reagir à crise. Cada sistema se inscreve no evento do núcleo.
nucleo.AoEntrarEmCrise += escudo.ReagirACrise;
nucleo.AoEntrarEmCrise += iluminacao.ReagirACrise;
nucleo.AoEntrarEmCrise += painel.ReagirACrise;

// ============================================================
// Registro das funções disponíveis para o tripulante.
// ============================================================

var registroFuncoes = new FuncaoTripulanteRegistro();

registroFuncoes.RegistrarFuncao("ocioso", new FuncaoOcioso());

registroFuncoes.RegistrarFuncao("mecanico", new FuncaoMecanico());

registroFuncoes.RegistrarFuncao("artilheiro", new FuncaoArtilheiro());

var tripulanteMercy = new Tripulante("Mercy");

// ============================================================
// Registro das armas disponíveis para a nave.
// ============================================================

var registroArmamentos = new ArmaRegistro();

registroArmamentos.RegistrarArma("desacoplado", new ArmaVazio());

registroArmamentos.RegistrarArma("laser", new ArmaLaser());

registroArmamentos.RegistrarArma("misseis", new ArmaMisseis());

var nave = new Nave();

// ============================================================
// Registro dos modificadores disponíveis para as armas.
// ============================================================

var registroModificadores = new ModificadorRegistro();

registroModificadores.RegistrarModificador("fogo", arma => new ModificadorFogo(arma));

registroModificadores.RegistrarModificador("perfuracao", arma => new ModificadorPerfuracao(arma));

// ============================================================
// Criação do Invoker do padrão Command.
// ============================================================

var gerenciador = new GerenciadorComandos();

// ============================================================
// Registro dos comandos disponíveis no console.
// ============================================================

// A variável controla a execução do loop principal.
// O comando "sair" altera esse valor para false.
bool executando = true;

// -------------------------
// Comandos relacionados ao núcleo.
// -------------------------

gerenciador.RegistrarComando(
    "tomar_dano",
    new ComandoTomarDano(nucleo),
    "tomar_dano <valor> - Aplica dano ao núcleo."
    );

// -------------------------
// Comandos relacionados ao tripulante.
// -------------------------

gerenciador.RegistrarComando(
    "trocar_funcao",
    new ComandoTrocarFuncao(tripulanteMercy, registroFuncoes),
    $"trocar_funcao <funcao> - Define a função do tripulante ({string.Join(", ", registroFuncoes.ListarNomes())})."
    );

gerenciador.RegistrarComando(
    "trabalhar",
    new ComandoTrabalhar(tripulanteMercy),
    "trabalhar - Manda o tripulante executar a tarefa da função atual."
    );

// -------------------------
// Comandos relacionados ao armamento.
// -------------------------

gerenciador.RegistrarComando(
    "equipar_arma",
    new ComandoEquiparArma(nave, registroArmamentos),
    $"equipar_arma <arma> - Equipa uma arma ({string.Join(", ", registroArmamentos.ListarNomes())})."
    );

gerenciador.RegistrarComando(
    "adicionar_modificador",
    new ComandoAdicionarModificador(nave, registroModificadores),
    $"adicionar_modificador <modificador> - Adiciona um modificador à arma ({string.Join(", ", registroModificadores.ListarNomes())})."
    );

gerenciador.RegistrarComando(
    "atirar",
    new ComandoAtirar(nave),
    "atirar - Dispara a arma equipada."
    );

// -------------------------
// Comandos de controle do console.
// -------------------------

gerenciador.RegistrarComando(
    "help",
    new ComandoAjuda(gerenciador),
    "help - Mostra os comandos disponíveis."
    );

gerenciador.RegistrarComando(
    "sair",
    new ComandoSair(() => executando = false),
    "sair - Encerra a aplicação."
    );

// ============================================================
// Inicialização da interface do console.
// ============================================================

Console.WriteLine("=========== Spaceship Command Center ==========");
Console.WriteLine("Digite 'help' para ver os comandos disponíveis.");
Console.WriteLine("Digite 'sair' para encerrar.");
Console.WriteLine("-----------------------------------------------");

// ============================================================
// Loop principal do console.
// ============================================================

while (executando)
{
    // Exibe o prompt para indicar que o programa está
    // aguardando um novo comando do usuário.
    Console.Write("> ");

    // Lê uma linha inteira digitada pelo usuário.
    // ReadLine() pode retornar null caso a entrada seja encerrada.
    string? entrada = Console.ReadLine();

    // Ignora entradas vazias e solicita um novo comando.
    if (string.IsNullOrWhiteSpace(entrada))
    {
        continue;
    }

    // Divide a entrada em partes utilizando o espaço como
    // separador.
    string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    // A primeira parte da entrada representa o nome do comando.
    //
    // ToLowerInvariant() normaliza o comando sem depender
    // das regras de capitalização da cultura do sistema.
    string nomeComando = partes[0].ToLowerInvariant();

    // Todas as partes restantes são consideradas argumentos
    // do comando.
    string[] argumentos = [.. partes.Skip(1)];

    // O GerenciadorComandos procura o comando no dicionário
    // e delega sua execução para a implementação correspondente.
    //
    // O loop não precisa conhecer nenhuma classe concreta de
    // comando, mantendo o baixo acoplamento proporcionado pelo
    // padrão Command.
    if (!gerenciador.ExecutarComando(nomeComando, argumentos))
    {
        // Caso o comando não esteja registrado, informa o usuário
        // e mantém o programa em execução.
        Console.WriteLine($"Comando '{nomeComando}' não reconhecido. Digite 'help' para ver os comandos disponíveis.");
    }
}