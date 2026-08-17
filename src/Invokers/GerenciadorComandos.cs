using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Invokers
{
    /// <summary>
    /// Invoker do padrão Command.
    /// Registra, localiza e executa comandos através de um dicionário.
    /// </summary>
    public class GerenciadorComandos
    {
        private readonly Dictionary<string, DefinicaoComando> _comandos = new();

        /// <summary>
        /// Registra um comando associado a um nome e uma descrição.
        /// </summary>
        /// <param name="nome">Nome utilizado para executar o comando.</param>
        /// <param name="comando">Instância do comando.</param>
        /// <param name="descricao">Descrição exibida pelo comando de ajuda.</param>
        public void RegistrarComando(string nome, IComando comando, string descricao)
        {
            _comandos[nome] = new DefinicaoComando(
                comando,
                descricao);
        }

        /// <summary>
        /// Executa um comando pelo nome.
        /// </summary>
        /// <param name="nome">Nome do comando.</param>
        /// <param name="args">Argumentos fornecidos pelo usuário.</param>
        /// <returns>
        /// True se o comando foi encontrado e executado;
        /// False caso o comando não esteja registrado.
        /// </returns>
        public bool ExecutarComando(string nome, string[] args)
        {
            if (_comandos.TryGetValue(nome, out DefinicaoComando? definicao))
            {
                definicao.Comando.Executar(args);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Retorna os comandos registrados em ordem alfabética.
        /// </summary>
        /// <returns>Lista ordenada com os nomes dos comandos.</returns>
        public IEnumerable<string> ListarComandos() => _comandos.Keys.OrderBy(nome => nome);

        /// <summary>
        /// Retorna as definições dos comandos registrados em ordem alfabética.
        /// </summary>
        /// <returns>Lista ordenada das definições dos comandos.</returns>
        public IEnumerable<DefinicaoComando> ListarDefinicoes() => _comandos.OrderBy(par => par.Key).Select(par => par.Value);
    }
}