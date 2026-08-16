
namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para todos os comandos do sistema (Command Pattern).
    /// </summary>
    public interface IComando
    {
        /// <summary>
        /// Executa a ação do comando.
        /// </summary>
        /// <param name="args">Argumentos do comando.</param>
        void Executar(string[] args);
    }
}