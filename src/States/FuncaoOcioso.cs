using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.States
{
    /// <summary>
    /// Estado concreto que representa a função ociosa (sem atividade).
    /// </summary>
    /// <remarks>
    /// Utilizado como estado padrão do tripulante quando nenhuma função está definida.
    /// </remarks>
    public class FuncaoOcioso : IFuncaoTripulante
    {
        /// <summary>
        /// Nome da função: "Ocioso(a)".
        /// </summary>
        public string Nome { get; } = "Ocioso(a)";

        /// <summary>
        /// Executa a ação de ficar ocioso, informando que o tripulante está sem função.
        /// </summary>
        /// <param name="tripulante">Tripulante que está executando a ação.</param>
        public void Trabalhar(Tripulante tripulante)
        {
            Console.WriteLine($"{tripulante.Nome} está sem função.");
        }
    }
}