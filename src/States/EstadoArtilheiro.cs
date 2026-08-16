using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.States
{
    public class EstadoArtilheiro : IFuncaoTripulante
    {
        public string Nome { get; } = "Artilheiro(a)";
        public void Trabalhar(Tripulante tripulante)
        {
            Console.WriteLine($"{tripulante.Nome} está atirando em naves inimigas.");
        }
    }
}