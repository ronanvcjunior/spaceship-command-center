using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Commands
{
    /// <summary>
    /// Comando para disparar a arma atualmente equipada na nave.
    /// </summary>
    public class ComandoAtirar(INave nave) : IComando
    {
        private readonly INave _nave = nave;

        /// <summary>
        /// Executa o comando, delegando o disparo à nave.
        /// </summary>
        /// <param name="args">Argumentos do comando (não utilizados).</param>
        public void Executar(string[] args)
        {
            _nave.Atirar();
        }
    }
}