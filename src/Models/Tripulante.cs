using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Strategies;

namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Representa um tripulante da nave. Atua como o Context no padrão Strategy.
    /// </summary>
    /// <remarks>
    /// O tripulante delega seu comportamento para uma estratégia concreta (<see cref="IFuncaoTripulante"/>).
    /// A função inicial padrão é <see cref="FuncaoOcioso"/>.
    /// </remarks>
    public class Tripulante(string nome) : ITripulante
    {
        /// <summary>
        /// Nome do tripulante.
        /// </summary>
        public string Nome { get; } = nome;

        private IFuncaoTripulante _funcao = new FuncaoOcioso();

        /// <summary>
        /// Substitui a função (estratégia) atual do tripulante.
        /// </summary>
        /// <param name="funcao">Nova estratégia a ser atribuída.</param>
        public void TrocarFuncao(IFuncaoTripulante funcao)
        {
            _funcao = funcao;
            Console.WriteLine($"[Tripulante] {Nome} agora é um(a) {_funcao.Nome}.");
        }

        /// <summary>
        /// Executa a tarefa da função atual, delegando à estratégia.
        /// </summary>
        public void Trabalhar() => _funcao.Trabalhar(this);
    }
}