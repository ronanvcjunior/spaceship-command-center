using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Strategies;

namespace spaceship_command_center.src.Models
{
    public class Nave : INave
    {
        private IArma _arma = new ArmaVazio();

        public void EquiparArma(IArma arma)
        {
            _arma = arma;
            Console.WriteLine($"[Nave] {_arma.Nome} equipado(a) com sucesso.");
        }

        public void Atirar() => _arma.Atirar();
    }
}