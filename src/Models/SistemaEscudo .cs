using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Models
{
    public class SistemaEscudo : IObservadorCrise
    {
        public void ReagirACrise()
        {
            Console.WriteLine("[Escudo] Redirecionando foco de defesa para o setor dianteiro!");
        }
    }
}