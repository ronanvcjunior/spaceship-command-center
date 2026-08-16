using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Strategies
{
    /// <summary>
    /// Estratégia concreta que representa a arma laser contínuo.
    /// </summary>
    public class ArmaLaser : IArma
    {
        /// <summary>
        /// Nome da arma: "Laser Contínuo".
        /// </summary>
        public string Nome { get; } = "Laser Contínuo";

        /// <summary>
        /// Executa o disparo de uma rajada contínua de laser.
        /// </summary>
        public void Atirar() => Console.WriteLine("Rajada contínua de laser.");
    }
}