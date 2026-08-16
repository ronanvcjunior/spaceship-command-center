using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Strategies
{
    /// <summary>
    /// Estratégia concreta que representa a ausência de arma (Null Object Pattern).
    /// </summary>
    /// <remarks>
    /// Utilizada como arma padrão da nave enquanto nenhuma arma real está equipada,
    /// evitando checagens de nulo nos comandos de disparo.
    /// </remarks>
    public class ArmaVazio : IArma
    {
        /// <summary>
        /// Nome da arma: "Nenhum".
        /// </summary>
        public string Nome { get; } = "Nenhum";

        /// <summary>
        /// Informa que nenhuma arma está equipada.
        /// </summary>
        public void Atirar() => Console.WriteLine("Nenhuma arma equipada.");
    }
}