using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Strategies
{
    public class ArmaLaser : IArma
    {
        public string Nome { get; } = "Laser Contínuo";

        public void Atirar() => Console.WriteLine("Rajada contínua de laser.");
    }
}