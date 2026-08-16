using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.States
{
    /// <summary>
    /// Estado concreto que representa a função de mecânico.
    /// </summary>
    public class FuncaoMecanico : IFuncaoTripulante
    {
        /// <summary>
        /// Nome da função: "Mecânico(a)".
        /// </summary>
        public string Nome { get; } = "Mecânico(a)";

        /// <summary>
        /// Executa a ação de inspecionar o reator e ajustar os escudos.
        /// </summary>
        /// <param name="tripulante">Tripulante que está executando a ação.</param>
        public void Trabalhar(Tripulante tripulante)
        {
            Console.WriteLine($"{tripulante.Nome} está inspecionando o reator de dobra e ajustando os escudos.");
        }
    }
}