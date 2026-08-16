using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Services
{
    public class ArmaRegistro
    {
        private readonly Dictionary<string, IArma> _armas = new();

        public void RegistrarArma(string nome, IArma arma)
        {
            _armas[nome.ToLower()] = arma;
        }

        public IArma? ObterArma(string nome)
        {
            _armas.TryGetValue(nome.ToLower(), out var arma);
            return arma;
        }

        public IEnumerable<string> ListarNomes() => _armas.Keys.OrderBy(k => k);
    }
}