using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Observer concreto. Redireciona o sistema de defesa durante a crise.
    /// </summary>
    public class SistemaEscudo : IObservadorCrise
    {
        /// <summary>
        /// Redireciona o foco de defesa para o setor dianteiro da nave.
        /// </summary>
        public void ReagirACrise()
        {
            Console.WriteLine("[Escudo] Redirecionando foco de defesa para o setor dianteiro!");
        }
    }
}