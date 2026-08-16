using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Services;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Comando para alterar a função (estratégia) atual do tripulante.
    /// </summary>
    public class ComandoTrocarFuncao(ITripulante tripulante, FuncaoTripulanteRegistro registro) : IComando
    {
        private readonly ITripulante _tripulante = tripulante;
        private readonly FuncaoTripulanteRegistro _registro = registro;

        /// <summary>
        /// Executa o comando, obtendo a estratégia pelo nome e atribuindo ao tripulante.
        /// </summary>
        /// <param name="args">Argumentos: [0] = nome da função (ex: "mecanico").</param>
        public void Executar(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: trocar_funcao <funcao>");
                return;
            }

            var funcao = _registro.ObterFuncao(args[0]);
            if (funcao == null)
            {
                Console.WriteLine($"Função '{args[0]}' não existe. Opções: {string.Join(", ", _registro.ListarNomes())}");
                return;
            }

            _tripulante.TrocarFuncao(funcao);
        }
    }
}