using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.States;

namespace spaceship_command_center.src.Models
{
    public class Tripulante(string nome)
    {
        public string Nome { get; } = nome;
        private IFuncaoTripulante _funcao = new EstadoOcioso();

        public void DefinirFuncao(IFuncaoTripulante novaFuncao)
        {
            _funcao = novaFuncao;
            Console.WriteLine($"[Tripulante] {Nome} agora é um(a) {_funcao.Nome}.");
        }

        public void Trabalhar() => _funcao.Trabalhar(this);

        public string ObterFuncaoAtual() => _funcao.Nome;
    }
}