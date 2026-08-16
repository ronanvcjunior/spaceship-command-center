using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Strategies
{
    public class ArmaMisseis : IArma
    {
        public string Nome { get; } = "Enxame de Mísseis";

        public void Atirar() => Console.WriteLine("Lançando enxame de mísseis!");
    }
}