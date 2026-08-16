using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Services
{
    public class ModificadorRegistro
    {
        private readonly Dictionary<string, Func<IArma, ModificadorArma>> _fabricas = new();

        public void RegistrarModificador(string nome, Func<IArma, ModificadorArma> fabrica)
        {
            _fabricas[nome.ToLower()] = fabrica;
        }

        public Func<IArma, ModificadorArma>? ObterFabrica(string nome)
        {
            _fabricas.TryGetValue(nome.ToLower(), out var fabrica);
            return fabrica;
        }

        public IEnumerable<string> ListarNomes() => _fabricas.Keys.OrderBy(k => k);
    }
}