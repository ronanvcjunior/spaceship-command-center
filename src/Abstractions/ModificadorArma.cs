namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Decorator base para modificadores de arma (Decorator Pattern).
    /// </summary>
    /// <remarks>
    /// Envolve uma <see cref="IArma"/> existente e permite acrescentar comportamento
    /// ao disparo sem alterar a implementação original da arma.
    /// </remarks>
    public abstract class ModificadorArma : IArma
    {
        /// <summary>
        /// Arma decorada (componente envolvido).
        /// </summary>
        protected readonly IArma _arma;

        /// <summary>
        /// Nome de exibição, herdado da arma decorada por padrão.
        /// </summary>
        public virtual string Nome { get; }

        /// <summary>
        /// Inicializa o decorator envolvendo a arma informada.
        /// </summary>
        /// <param name="arma">Arma a ser decorada.</param>
        protected ModificadorArma(IArma arma)
        {
            _arma = arma;
            Nome = _arma.Nome;
        }

        /// <summary>
        /// Delega o disparo para a arma decorada.
        /// </summary>
        public virtual void Atirar() => _arma.Atirar();
    }
}