using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.Strategies
{
    /// <summary>
    /// Estratégia concreta que representa a função de artilheiro.
    /// </summary>
    public class FuncaoArtilheiro : IFuncaoTripulante
    {
        /// <summary>
        /// Nome da função: "Artilheiro(a)".
        /// </summary>
        public string Nome { get; } = "Artilheiro(a)";

        /// <summary>
        /// Executa a ação de atirar em naves inimigas.
        /// </summary>
        /// <param name="tripulante">Tripulante que está executando a ação.</param>
        public void Trabalhar(Tripulante tripulante)
        {
            Console.WriteLine($"{tripulante.Nome} está atirando em naves inimigas.");
        }
    }
}