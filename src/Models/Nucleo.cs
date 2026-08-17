namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Gerencia a energia do núcleo da nave. Atua como Subject no padrão Observer.
    /// </summary>
    /// <remarks>
    /// Dispara o evento <see cref="AoEntrarEmCrise"/> quando a energia atinge o nível crítico.
    /// A notificação ocorre apenas uma vez por ciclo de crise.
    /// </remarks>
    public class Nucleo(int energia, int nivelCritico)
    {
        /// <summary>
        /// Energia atual do núcleo.
        /// </summary>
        public int Energia { get; private set; } = energia;
        private readonly int _nivelCritico = nivelCritico;
        private bool _emNivelCritico;

        /// <summary>
        /// Evento disparado quando a energia atinge o nível crítico.
        /// </summary>
        public event Action? AoEntrarEmCrise;

        /// <summary>
        /// Aplica dano ao núcleo e verifica se entrou em estado crítico.
        /// </summary>
        /// <param name="dano">Quantidade de dano.</param>
        public void TomarDano(int dano)
        {
            if (Energia <= 0)
            {
                Console.WriteLine("[Núcleo] Sistema já está desativado. Danos ignorados.");
                return;
            }

            if (dano <= 0)
            {
                Console.WriteLine("[Núcleo] O dano deve ser maior que zero.");
                return;
            }

            Energia = Math.Max(0, Energia - dano);
            Console.WriteLine($"[Núcleo] Energia atual: {Energia}%.");

            if (Energia <= _nivelCritico && !_emNivelCritico)
            {
                _emNivelCritico = true;
                Console.WriteLine($"[Núcleo] *** ESTADO CRÍTICO DETECTADO! ({Energia}%) ***");
                AoEntrarEmCrise?.Invoke();
            }

            if (Energia == 0)
            {
                Console.WriteLine("[Núcleo] Núcleo desligado permanentemente.");
            }
        }
    }
}