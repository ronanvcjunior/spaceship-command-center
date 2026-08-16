using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.States
{
    public class EstadoOcioso : IFuncaoTripulante
    {
        public string Nome { get; } = "Ocioso(a)";

        public void Trabalhar(Tripulante tripulante)
        {
            Console.WriteLine($"{tripulante.Nome} está sem função.");
        }
    }
}