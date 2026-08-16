using spaceship_command_center.src.Commands;
using spaceship_command_center.src.Invokers;
using spaceship_command_center.src.Models;
using spaceship_command_center.src.States;

var nucleo = new Nucleo(100, 20);
var escudo = new SistemaEscudo();
var iluminacao = new SistemaIluminacao();
var painel = new PainelNavegacao();

nucleo.AoEntrarEmCrise += escudo.ReagirACrise;
nucleo.AoEntrarEmCrise += iluminacao.ReagirACrise;
nucleo.AoEntrarEmCrise += painel.ReagirACrise;

var tripulanteMercy = new Tripulante("Mercy");

var gerenciador = new GerenciadorComandos();

gerenciador.RegistrarComando("tomar_dano", new ComandoTomarDano(nucleo));

Console.WriteLine("=== Spaceship Command Center ===");
Console.WriteLine("Comandos disponíveis:");
Console.WriteLine("  tomar_dano <valor>   - Aplica dano ao núcleo");
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