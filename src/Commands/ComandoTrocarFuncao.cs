using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Comando para alterar a função atual do tripulante.
    /// </summary>
    public class ComandoTrocarFuncao(ITripulante tripulante) : IComando
    {
        private readonly ITripulante _tripulante = tripulante;

        /// <summary>
        /// Executa o comando, repassando o nome da função ao tripulante.
        /// </summary>
        /// <param name="args">Argumentos: [0] = nome da função (ex: "mecanico").</param>
        public void Executar(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: trocar_funcao <funcao>");
                return;
            }

            _tripulante.TrocarFuncao(args[0]);
        }
    }
}