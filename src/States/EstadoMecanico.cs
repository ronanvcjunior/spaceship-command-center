using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.States
{
    public class EstadoMecanico : IFuncaoTripulante
    {
        public string Nome { get; } = "Mecânico(a)";

        public void Trabalhar(Tripulante tripulante)
        {
            Console.WriteLine($"{tripulante.Nome} está inspecionando o reator de dobra e ajustando os escudos.");
        }
    }
}