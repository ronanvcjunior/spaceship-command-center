using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Decorators
{
    public class ModificadorPerfuracao(IArma arma) : ModificadorArma(arma)
    {
        public override string Nome => base.Nome + " Perfuração";

        public override void Atirar()
        {
            base.Atirar();
            Console.WriteLine("[derretendo a Blindagem inimiga!]");
        }
    }
}