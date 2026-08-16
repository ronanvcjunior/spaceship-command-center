using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Services;

namespace spaceship_command_center.src.Commands
{
    public class ComandoAdicionarModificador : IComando
    {
        private readonly INave _nave;
        private readonly ModificadorRegistro _registro;

        public ComandoAdicionarModificador(INave nave, ModificadorRegistro registro)
        {
            _nave = nave;
            _registro = registro;
        }

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