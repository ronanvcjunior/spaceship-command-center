using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Invokers
{
    /// <summary>
    /// Invoker do padrão Command. Registra e executa comandos via dicionário.
    /// </summary>
    public class GerenciadorComandos
    {
        private readonly Dictionary<string, IComando> _comandos = new();

        /// <summary>
        /// Registra um comando associado a um nome.
        /// </summary>
        /// <param name="nome">Nome do comando (ex: "tomar_dano").</param>
        /// <param name="comando">Instância do comando.</param>
        public void RegistrarComando(string nome, IComando comando)
        {
            _comandos[nome] = comando;
        }

        /// <summary>
        /// Executa um comando pelo nome.
        /// </summary>
        /// <param name="nome">Nome do comando.</param>
        /// <param name="args">Argumentos para o comando.</param>
        /// <returns>True se encontrado e executado; False caso contrário.</returns>
        public bool ExecutarComando(string nome, string[] args)
        {
            if (_comandos.TryGetValue(nome, out IComando? comando))
            {
                comando.Executar(args);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lista os nomes dos comandos registrados em ordem alfabética.
        /// </summary>
        /// <returns>Lista ordenada de nomes de comandos.</returns>
        public IEnumerable<string> ListarComandos()
        {
            return _comandos.Keys.OrderBy(k => k);
        }
    }
}