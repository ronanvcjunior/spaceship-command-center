namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para as armas equipáveis na nave (Strategy Pattern).
    /// </summary>
    public interface IArma
    {
        /// <summary>
        /// Nome de exibição da arma.
        /// </summary>
        string Nome { get; }

        /// <summary>
        /// Executa a ação de disparo da arma.
        /// </summary>
        void Atirar();
    }
}