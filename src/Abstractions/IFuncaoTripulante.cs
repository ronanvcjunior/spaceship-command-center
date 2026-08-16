using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para as funções do tripulante (State Pattern).
    /// </summary>
    public interface IFuncaoTripulante
    {
        /// <summary>
        /// Nome da função
        /// </summary>
        public string Nome { get; }

         /// <summary>
        /// Executa a tarefa associada à função do tripulante.
        /// </summary>
        /// <param name="tripulante">Referência ao tripulante que está executando a ação.</param>
        public void Trabalhar(Tripulante tripulante);
    }
}