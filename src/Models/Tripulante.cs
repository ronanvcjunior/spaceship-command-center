using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Registers;
using spaceship_command_center.src.States;

namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Representa um tripulante da nave. Atua como Context no padrão State.
    /// </summary>
    /// <remarks>
    /// Delega o comportamento para o estado atual (IFuncaoTripulante).
    /// A função inicial padrão é <see cref="FuncaoOcioso"/>.
    /// </remarks>
    public class Tripulante(string nome, FuncaoTripulanteRegistro registro) : ITripulante
    {
        /// <summary>
        /// Nome do tripulante.
        /// </summary>
        public string Nome { get; } = nome;

        private IFuncaoTripulante _funcao = new FuncaoOcioso();
        private readonly FuncaoTripulanteRegistro _registro = registro;

        /// <summary>
        /// Troca a função atual do tripulante.
        /// </summary>
        /// <param name="nomeFuncao">Nome da função.</param>
        public void TrocarFuncao(string nomeFuncao)
        {
            var novoEstado = _registro.ObterFuncao(nomeFuncao);
            if (novoEstado == null)
            {
                Console.WriteLine($"Função '{nomeFuncao}' não existe. Opções: {string.Join(", ", _registro.ListarNomes())}");
                return;
            }

            _funcao = novoEstado;
            Console.WriteLine($"[Tripulante] {Nome} agora é um(a) {_funcao.Nome}.");
        }

        /// <summary>
        /// Executa a tarefa da função atual do tripulante.
        /// </summary>
        public void Trabalhar() => _funcao.Trabalhar(this);

        /// <summary>
        /// Obtém o nome da função atual do tripulante.
        /// </summary>
        /// <returns>Nome da função atual.</returns>
        public string ObterFuncaoAtual() => _funcao.Nome;
    }
}