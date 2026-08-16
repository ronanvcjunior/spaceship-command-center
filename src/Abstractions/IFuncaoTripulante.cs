using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.Abstractions
{
    public interface IFuncaoTripulante
    {
        public void Trabalhar(Tripulante tripulante);
        public string Nome { get; }
    }
}