using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Observer concreto. Exibe alertas no painel de navegação durante a crise.
    /// </summary>
    public class PainelNavegacao : IObservadorCrise
    {
        /// <summary>
        /// Exibe alertas visuais no painel quando a crise é detectada.
        /// </summary>
        public void ReagirACrise()
        {
            Console.WriteLine("[Painel] ATENÇÃO! Sinais de alerta exibidos no painel de navegação!");
        }
    }
}