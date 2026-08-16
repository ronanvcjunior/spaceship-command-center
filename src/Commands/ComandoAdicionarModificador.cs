using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Services;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Comando para envolver a arma atual da nave com um modificador (Decorator).
    /// </summary>
    public class ComandoAdicionarModificador : IComando
    {
        private readonly INave _nave;
        private readonly ModificadorRegistro _registro;

        /// <summary>
        /// Inicializa o comando com a nave alvo e o registro de fábricas de modificadores.
        /// </summary>
        /// <param name="nave">Nave cuja arma será decorada.</param>
        /// <param name="registro">Registro contendo as fábricas de modificadores disponíveis.</param>
        public ComandoAdicionarModificador(INave nave, ModificadorRegistro registro)
        {
            _nave = nave;
            _registro = registro;
        }

        /// <summary>
        /// Executa o comando, obtendo a fábrica pelo nome e envolvendo a arma atual da nave.
        /// </summary>
        /// <param name="args">Argumentos: [0] = nome do modificador (ex: "fogo").</param>
        public void Executar(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Uso: adicionar_modificador <modificador>. Opções: {string.Join(", ", _registro.ListarNomes())}");
                return;
            }

            var fabrica = _registro.ObterFabrica(args[0]);
            if (fabrica == null)
            {
                Console.WriteLine($"Modificador '{args[0]}' não existe.");
                return;
            }

            // Cria o modificador envolvendo a arma atual
            var novoModificador = fabrica(_nave.Arma);
            _nave.EquiparArma(novoModificador);
        }
    }
}