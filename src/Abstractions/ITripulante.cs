namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para a interação com um tripulante da nave (Context do Strategy Pattern).
    /// </summary>
    public interface ITripulante
    {
        /// <summary>
        /// Define a função (estratégia) atual do tripulante.
        /// </summary>
        /// <param name="funcao">Instância da estratégia a ser atribuída.</param>
        void TrocarFuncao(IFuncaoTripulante funcao);

        /// <summary>
        /// Executa a tarefa associada à função atual do tripulante.
        /// </summary>
        void Trabalhar();
    }
}