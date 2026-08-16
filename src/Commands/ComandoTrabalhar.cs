using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Comando para fazer o tripulante executar sua função atual.
    /// </summary>
    public class ComandoTrabalhar(ITripulante tripulante) : IComando
    {
        private readonly ITripulante _tripulante = tripulante;

        /// <summary>
        /// Executa o comando, delegando a ação ao tripulante.
        /// </summary>
        /// <param name="args">Argumentos do comando (não utilizados).</param>
        public void Executar(string[] args) => _tripulante.Trabalhar();
    }
}