using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Models
{
    public class PainelNavegacao : IObservadorCrise
    {
        public void ReagirACrise()
        {
            Console.WriteLine("[Painel] ATENÇÃO! Sinais de alerta exibidos no painel de navegação!");
        }
    }
}