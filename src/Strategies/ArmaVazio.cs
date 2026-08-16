using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Strategies
{
    public class ArmaVazio : IArma
    {
        public string Nome { get; } = "Nenhum";

        public void Atirar() => Console.WriteLine("Nenhuma arma equipada.");
    }
}