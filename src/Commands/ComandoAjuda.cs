using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Invokers;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Command responsável por exibir os comandos disponíveis
    /// e suas respectivas descrições.
    /// </summary>
    public class ComandoAjuda(GerenciadorComandos gerenciador) : IComando
    {
        private readonly GerenciadorComandos _gerenciador = gerenciador;

        /// <summary>
        /// Exibe no console a lista de comandos registrados
        /// e suas descrições.
        /// </summary>
        /// <param name="args">
        /// Argumentos fornecidos pelo usuário. Este comando não utiliza argumentos.
        /// </param>
        public void Executar(string[] args)
        {
            Console.WriteLine("Comandos disponíveis:");

            foreach (var definicao in _gerenciador.ListarDefinicoes())
            {
                Console.WriteLine($" - {definicao.Descricao}");
            }
        }
    }
}