namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para a interação com um tripulante da nave (State Pattern).
    /// </summary>
    public interface ITripulante
    {
        /// <summary>
        /// Troca a função atual do tripulante para uma nova, identificada pelo nome.
        /// </summary>
        /// <param name="nomeFuncao">Nome da função.</param>
        void TrocarFuncao(string nomeFuncao);

        /// <summary>
        /// Executa a tarefa associada à função atual do tripulante.
        /// </summary>
        void Trabalhar();
    }
}