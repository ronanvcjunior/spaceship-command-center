using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Commands
{
    public class ComandoTrabalhar(ITripulante tripulante) : IComando
    {
        private readonly ITripulante _tripulante = tripulante;

        public void Executar(string[] args) => _tripulante.Trabalhar();
    }
}