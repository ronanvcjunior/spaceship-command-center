using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Comando para aplicar dano ao núcleo.
    /// </summary>
    public class ComandoTomarDano(Nucleo nucleo) : IComando
    {
        private readonly Nucleo _nucleo = nucleo;

        /// <summary>
        /// Executa o comando, validando o argumento e chamando <see cref="Nucleo.TomarDano"/>.
        /// </summary>
        /// <param name="args">Argumentos: [0] = quantidade de dano (inteiro).</param>
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