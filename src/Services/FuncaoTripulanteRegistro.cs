using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Services
{
    /// <summary>
    /// Registro centralizado de funções (estratégias) do tripulante.
    /// </summary>
    /// <remarks>
    /// Permite registrar e recuperar funções por nome, garantindo o desacoplamento
    /// entre o <see cref="Tripulante"/> (Context do Strategy Pattern) e as classes
    /// concretas que implementam <see cref="IFuncaoTripulante"/> (as estratégias).
    /// </remarks>
    public class FuncaoTripulanteRegistro
    {
        private readonly Dictionary<string, IFuncaoTripulante> _funcoes = new();

        /// <summary>
        /// Registra uma função associada a um nome.
        /// </summary>
        /// <param name="nome">Nome da função (case-insensitive).</param>
        /// <param name="funcao">Instância da função que implementa <see cref="IFuncaoTripulante"/>.</param>
        public void RegistrarFuncao(string nome, IFuncaoTripulante funcao)
        {
            _funcoes[nome.ToLower()] = funcao;
        }

        /// <summary>
        /// Recupera uma função pelo nome.
        /// </summary>
        /// <param name="nome">Nome da função (case-insensitive).</param>
        /// <returns>
        /// Instância da função se encontrada; caso contrário, <c>null</c>.
        /// </returns>
        public IFuncaoTripulante? ObterFuncao(string nome)
        {
            _funcoes.TryGetValue(nome.ToLower(), out var funcao);
            return funcao;
        }

        /// <summary>
        /// Lista os nomes das funções registradas em ordem alfabética.
        /// </summary>
        /// <returns>Lista ordenada de nomes de funções.</returns>
        public IEnumerable<string> ListarNomes() => _funcoes.Keys.OrderBy(k => k);
    }
}