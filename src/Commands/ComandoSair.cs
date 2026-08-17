using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Command responsável por solicitar o encerramento da aplicação.
    /// </summary>
    public class ComandoSair(Action solicitarSaida) : IComando
    {
        private readonly Action _solicitarSaida = solicitarSaida;

        /// <summary>
        /// Executa o comando de saída e solicita o encerramento
        /// do loop principal da aplicação.
        /// </summary>
        /// <param name="args">
        /// Argumentos fornecidos pelo usuário. Este comando não utiliza argumentos.
        /// </param>
        public void Executar(string[] args)
        {
            Console.WriteLine("Encerrando a central de comandos...");
            _solicitarSaida();
        }
    }
}