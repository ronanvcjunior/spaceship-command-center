
using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Services;

namespace spaceship_command_center.src.Commands
{
    public class ComandoEquiparArma(INave nave, ArmaRegistro registro) : IComando
    {
        private readonly INave _nave = nave;
        private readonly ArmaRegistro _registro = registro;

        public void Executar(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Uso: equipar_arma <arma>. Opções: {string.Join(", ", _registro.ListarNomes())}");
                return;
            }

            var arma = _registro.ObterArma(args[0]);
            if (arma == null)
            {
                Console.WriteLine($"Arma '{args[0]}' não existe. Opções: {string.Join(", ", _registro.ListarNomes())}");
                return;
            }

            _nave.EquiparArma(arma);
        }
    }
}