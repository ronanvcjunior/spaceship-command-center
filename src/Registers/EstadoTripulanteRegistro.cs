using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Registers
{
    public class EstadoTripulanteRegistro
    {
        private readonly Dictionary<string, IFuncaoTripulante> _estados = new();

        public void RegistrarEstado(string nome, IFuncaoTripulante estado)
        {
            _estados[nome.ToLower()] = estado;
        }

        public IFuncaoTripulante? ObterEstado(string nome)
        {
            _estados.TryGetValue(nome.ToLower(), out var estado);
            return estado;
        }

        public IEnumerable<string> ListarNomes() => _estados.Keys.OrderBy(k => k);
    }
}