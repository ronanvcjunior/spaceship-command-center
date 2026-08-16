namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Reage à crise ativando a iluminação de emergência.
    /// </summary>
    public class SistemaIluminacao
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