using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Registers;
using spaceship_command_center.src.States;

namespace spaceship_command_center.src.Models
{
    public class Tripulante(string nome, EstadoTripulanteRegistro registro) : ITripulante
    {
        public string Nome { get; } = nome;
        private IFuncaoTripulante _funcao = new EstadoOcioso();

        private readonly EstadoTripulanteRegistro _registro = registro;

        public void TrocarFuncao(string nomeFuncao)
        {
            var novoEstado = _registro.ObterEstado(nomeFuncao);
            if (novoEstado == null)
            {
                Console.WriteLine($"Função '{nomeFuncao}' não existe. Opções: {string.Join(", ", _registro.ListarNomes())}");
                return;
            }

            _funcao = novoEstado;
            Console.WriteLine($"[Tripulante] {Nome} agora é um(a) {_funcao.Nome}.");
        }

        public void Trabalhar() => _funcao.Trabalhar(this);

        public string ObterFuncaoAtual() => _funcao.Nome;
    }
}