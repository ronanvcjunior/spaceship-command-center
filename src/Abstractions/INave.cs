namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para a nave, responsável por gerenciar e disparar o armamento equipado.
    /// </summary>
    public interface INave
    {
        /// <summary>
        /// Arma atualmente equipada na nave.
        /// </summary>
        IArma Arma { get; }

        /// <summary>
        /// Substitui a arma equipada pela informada.
        /// </summary>
        /// <param name="armamento">Nova arma (ou decorator de arma) a ser equipada.</param>
        void EquiparArma(IArma armamento);

        /// <summary>
        /// Executa o disparo utilizando a arma atualmente equipada.
        /// </summary>
        public void Atirar();
    }
}