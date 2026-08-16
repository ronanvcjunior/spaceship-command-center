namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Reage à crise exibindo alertas no painel de navegação.
    /// </summary>
    public class PainelNavegacao
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