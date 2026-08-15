using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.Commands
{
    public class ComandoTomarDano(Nucleo nucleo) : IComando
    {
        private readonly Nucleo _nucleo = nucleo;
        public void Executar(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: tomar_dano <quantidade>");
                return;
            }

            if (!int.TryParse(args[0], out int dano))
            {
                Console.WriteLine("Valor inválido. Digite um número inteiro.");
                return;
            }

            _nucleo.TomarDano(dano);
        }
    }
}