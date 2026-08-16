using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Strategies
{
    /// <summary>
    /// Estratégia concreta que representa a arma de mísseis.
    /// </summary>
    public class ArmaMisseis : IArma
    {
        /// <summary>
        /// Nome da arma: "Enxame de Mísseis".
        /// </summary>
        public string Nome { get; } = "Enxame de Mísseis";

        /// <summary>
        /// Executa o disparo de um enxame de mísseis.
        /// </summary>
        public void Atirar() => Console.WriteLine("Lançando enxame de mísseis!");
    }
}