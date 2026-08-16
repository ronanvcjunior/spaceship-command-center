using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.States;

namespace spaceship_command_center.src.Commands
{
    public class ComandoTrocarFuncao(ITripulante tripulante) : IComando
    {
        private readonly ITripulante _tripulante = tripulante;
        
        public void Executar(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: trocar_funcao <funcao>");
                return;
            }

            _tripulante.TrocarFuncao(args[0]);
        }
    }
}