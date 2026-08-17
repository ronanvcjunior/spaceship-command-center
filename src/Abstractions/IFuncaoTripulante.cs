using spaceship_command_center.src.Models;

namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Define o contrato para as diferentes funções que um tripulante
    /// pode desempenhar.
    /// 
    /// Representa a interface Strategy do padrão Strategy,
    /// permitindo que o comportamento do tripulante seja alterado
    /// dinamicamente durante a execução.
    /// </summary>
    public interface IFuncaoTripulante
    {
        /// <summary>
        /// Obtém o nome da função desempenhada pelo tripulante.
        /// </summary>
        string Nome { get; }

        /// <summary>
        /// Executa a tarefa correspondente à função atual do tripulante.
        /// </summary>
        /// <param name="tripulante">
        /// Referência ao tripulante que está executando a tarefa.
        /// </param>
        void Trabalhar(Tripulante tripulante);
    }
}