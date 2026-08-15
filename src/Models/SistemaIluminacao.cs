using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Models
{
    public class SistemaIluminacao : IObservadorCrise
    {
        public void ReagirACrise()
        {
            Console.WriteLine("[Iluminação] Luzes principais apagadas. Iluminação de emergência ativada.");
        }
    }
}