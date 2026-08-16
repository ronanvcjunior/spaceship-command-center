using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Strategies;

namespace spaceship_command_center.src.Models
{
    public class Nave : INave
    {
        public IArma Arma { get; private set; } = new ArmaVazio();

        public void EquiparArma(IArma arma)
        {
            Arma = arma;
            Console.WriteLine($"[Nave] {Arma.Nome} equipado(a) com sucesso.");
        }

        public void Atirar() => Arma.Atirar();
    }
}