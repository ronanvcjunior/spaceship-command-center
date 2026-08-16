using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Commands
{
    public class ComandoAtirar(INave nave) : IComando
    {
        private readonly INave _nave = nave;

        public void Executar(string[] args)
        {
            _nave.Atirar();
        }
    }
}