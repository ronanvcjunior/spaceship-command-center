namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para componentes de armamento da nave.
    /// É utilizado pelas armas base e pelos decorators de arma.
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