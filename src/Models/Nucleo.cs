namespace spaceship_command_center.src.Models
{
    public class Nucleo(int energia, int nivelCritico)
    {
        public int Energia { get; private set; } = energia;
        private readonly int _nivelCritico = nivelCritico;
        private bool _emNivelCritico;

        public event Action? AoEntrarEmCrise;

        public void TomarDano(int dano)
        {
            if (Energia <= 0)
            {
                Console.WriteLine("[Núcleo] Sistema já está desativado. Danos ignorados.");
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