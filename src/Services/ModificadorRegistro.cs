using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Services
{
    /// <summary>
    /// Registro centralizado de fábricas de modificadores de arma (Decorator Pattern).
    /// </summary>
    /// <remarks>
    /// Permite registrar e recuperar fábricas por nome, cada uma responsável por
    /// envolver uma <see cref="IArma"/> existente em um novo <see cref="ModificadorArma"/>.
    /// </remarks>
    public class ModificadorRegistro
    {
        private readonly Dictionary<string, Func<IArma, ModificadorArma>> _fabricas = new();

        /// <summary>
        /// Registra uma fábrica de modificador associada a um nome.
        /// </summary>
        /// <param name="nome">Nome do modificador (case-insensitive).</param>
        /// <param name="fabrica">Função que envolve uma <see cref="IArma"/> em um <see cref="ModificadorArma"/>.</param>
        public void RegistrarModificador(string nome, Func<IArma, ModificadorArma> fabrica)
        {
            _fabricas[nome.ToLower()] = fabrica;
        }

        /// <summary>
        /// Recupera a fábrica de um modificador pelo nome.
        /// </summary>
        /// <param name="nome">Nome do modificador (case-insensitive).</param>
        /// <returns>Fábrica do modificador se encontrada; caso contrário, <c>null</c>.</returns>
        public Func<IArma, ModificadorArma>? ObterFabrica(string nome)
        {
            _fabricas.TryGetValue(nome.ToLower(), out var fabrica);
            return fabrica;
        }

        /// <summary>
        /// Lista os nomes dos modificadores registrados em ordem alfabética.
        /// </summary>
        /// <returns>Lista ordenada de nomes de modificadores.</returns>
        public IEnumerable<string> ListarNomes() => _fabricas.Keys.OrderBy(k => k);
    }
}