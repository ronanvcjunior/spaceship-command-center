using spaceship_command_center.src.Commands;
using spaceship_command_center.src.Decorators;
using spaceship_command_center.src.Invokers;
using spaceship_command_center.src.Models;
using spaceship_command_center.src.Services;
using spaceship_command_center.src.Strategies;

var nucleo = new Nucleo(100, 20);
var escudo = new SistemaEscudo();
var iluminacao = new SistemaIluminacao();
var painel = new PainelNavegacao();

nucleo.AoEntrarEmCrise += escudo.ReagirACrise;
nucleo.AoEntrarEmCrise += iluminacao.ReagirACrise;
nucleo.AoEntrarEmCrise += painel.ReagirACrise;

var registroFuncoes = new FuncaoTripulanteRegistro();
registroFuncoes.RegistrarFuncao("ocioso", new FuncaoOcioso());
registroFuncoes.RegistrarFuncao("mecanico", new FuncaoMecanico());
registroFuncoes.RegistrarFuncao("artilheiro", new FuncaoArtilheiro());

var tripulanteMercy = new Tripulante("Mercy");

var registroArmamentos = new ArmaRegistro();
registroArmamentos.RegistrarArma("desacoplado", new ArmaVazio());
registroArmamentos.RegistrarArma("laser", new ArmaLaser());
registroArmamentos.RegistrarArma("misseis", new ArmaMisseis());

var nave = new Nave();

var registroModificadores = new ModificadorRegistro();
registroModificadores.RegistrarModificador("fogo", arma => new ModificadorFogo(arma));
registroModificadores.RegistrarModificador("perfuracao", arma => new ModificadorPerfuracao(arma));

var gerenciador = new GerenciadorComandos();

gerenciador.RegistrarComando("tomar_dano", new ComandoTomarDano(nucleo));
gerenciador.RegistrarComando("trocar_funcao", new ComandoTrocarFuncao(tripulanteMercy, registroFuncoes));
gerenciador.RegistrarComando("trabalhar", new ComandoTrabalhar(tripulanteMercy));
gerenciador.RegistrarComando("equipar_arma", new ComandoEquiparArma(nave, registroArmamentos));
gerenciador.RegistrarComando("atirar", new ComandoAtirar(nave));
gerenciador.RegistrarComando("adicionar_modificador", new ComandoAdicionarModificador(nave, registroModificadores));

Console.WriteLine("=== Spaceship Command Center ===");
Console.WriteLine("Comandos disponíveis:");
Console.WriteLine("  tomar_dano <valor>                     - Aplica dano ao núcleo");
Console.WriteLine($"  trocar_funcao <funcao>                 - Define a função do tripulante ({string.Join(", ", registroFuncoes.ListarNomes())})");
Console.WriteLine("  trabalhar                              - Dita o tripulante a executar o trabalho");
Console.WriteLine($"  equipar_arma <arma>                    - Define o arma da nave ({string.Join(", ", registroArmamentos.ListarNomes())})");
Console.WriteLine($"  adicionar_modificador <modificador>    - adiciona modificador na arma ({string.Join(", ", registroModificadores.ListarNomes())})");
Console.WriteLine("  atirar                                 - Dita a nave a atirar");
Console.WriteLine("----------------------------");

while (true)
{
    Console.Write("> ");
    string? entrada = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(entrada))
        continue;

    string[] partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    string nomeComando = partes[0].ToLower();
    string[] argumentos = [.. partes.Skip(1)];
    
    if (!gerenciador.ExecutarComando(nomeComando, argumentos))
    {
        Console.WriteLine($"Comando '{nomeComando}' não reconhecido.");
    }
}