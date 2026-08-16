using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Services
{
    /// <summary>
    /// Registro centralizado de armas disponíveis para equipar na nave.
    /// </summary>
    /// <remarks>
    /// Permite registrar e recuperar armas por nome, desacoplando os comandos
    /// do console das classes concretas que implementam <see cref="IArma"/>.
    /// </remarks>
    public class ArmaRegistro
    {
        private readonly Dictionary<string, IArma> _armas = new();

        /// <summary>
        /// Registra uma arma associada a um nome.
        /// </summary>
        /// <param name="nome">Nome da arma (case-insensitive).</param>
        /// <param name="arma">Instância da arma que implementa <see cref="IArma"/>.</param>
        public void RegistrarArma(string nome, IArma arma)
        {
            _armas[nome.ToLower()] = arma;
        }

        /// <summary>
        /// Recupera uma arma pelo nome.
        /// </summary>
        /// <param name="nome">Nome da arma (case-insensitive).</param>
        /// <returns>Instância da arma se encontrada; caso contrário, <c>null</c>.</returns>
        public IArma? ObterArma(string nome)
        {
            _armas.TryGetValue(nome.ToLower(), out var arma);
            return arma;
        }

        /// <summary>
        /// Lista os nomes das armas registradas em ordem alfabética.
        /// </summary>
        /// <returns>Lista ordenada de nomes de armas.</returns>
        public IEnumerable<string> ListarNomes() => _armas.Keys.OrderBy(k => k);
    }
}