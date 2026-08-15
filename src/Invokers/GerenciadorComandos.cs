using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Invokers
{
    public class GerenciadorComandos
    {
        private readonly Dictionary<string, IComando> _comandos = new();

        public void RegistrarComando(string nome, IComando comando)
        {
            _comandos[nome] = comando;
        }

        public bool ExecutarComando(string nome, string[] args)
        {
            if (_comandos.TryGetValue(nome, out IComando? comando))
            {
                comando.Executar(args);
                return true;
            }
            return false;
        }

        public IEnumerable<string> ListarComandos()
        {
            return _comandos.Keys.OrderBy(k => k);
        }
    }
}