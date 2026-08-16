using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Decorators
{
    public class ModificadorFogo(IArma arma) : ModificadorArma(arma)
    {
        public override string Nome => base.Nome + " Fogo";

        public override void Atirar()
        {
            base.Atirar();
            Console.WriteLine("[causando Dano de Fogo continuo!]");
        }
    }
}