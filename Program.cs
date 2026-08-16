using spaceship_command_center.src.Commands;
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

var registro = new FuncaoTripulanteRegistro();
registro.RegistrarFuncao("ocioso", new FuncaoOcioso());
registro.RegistrarFuncao("mecanico", new FuncaoMecanico());
registro.RegistrarFuncao("artilheiro", new FuncaoArtilheiro());

var tripulanteMercy = new Tripulante("Mercy");

var gerenciador = new GerenciadorComandos();

gerenciador.RegistrarComando("tomar_dano", new ComandoTomarDano(nucleo));
gerenciador.RegistrarComando("trocar_funcao", new ComandoTrocarFuncao(tripulanteMercy, registro));
gerenciador.RegistrarComando("trabalhar", new ComandoTrabalhar(tripulanteMercy));

Console.WriteLine("=== Spaceship Command Center ===");
Console.WriteLine("Comandos disponíveis:");
Console.WriteLine("  tomar_dano <valor>         - Aplica dano ao núcleo");
Console.WriteLine($"  trocar_funcao <funcao>     - Define a função do tripulante ({string.Join(", ", registro.ListarNomes())})");
Console.WriteLine("  trabalhar                  - Dita o tripulante a executar o trabalho");
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