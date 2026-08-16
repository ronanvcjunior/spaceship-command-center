using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Observer concreto. Gerencia a iluminação da nave durante a crise.
    /// </summary>
    public class SistemaIluminacao : IObservadorCrise
    {
        /// <summary>
        /// Apaga as luzes principais e ativa a iluminação de emergência.
        /// </summary>
        public void ReagirACrise()
        {
            Console.WriteLine("[Iluminação] Luzes principais apagadas. Iluminação de emergência ativada.");
        }
    }
}