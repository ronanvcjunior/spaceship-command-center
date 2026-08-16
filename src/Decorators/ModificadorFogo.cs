using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Decorators
{
    /// <summary>
    /// Decorator concreto que adiciona dano de fogo contínuo ao disparo da arma decorada.
    /// </summary>
    public class ModificadorFogo(IArma arma) : ModificadorArma(arma)
    {
        /// <summary>
        /// Nome da arma decorada com o sufixo "Fogo".
        /// </summary>
        public override string Nome => base.Nome + " Fogo";

        /// <summary>
        /// Executa o disparo original e adiciona o efeito de dano de fogo contínuo.
        /// </summary>
        public override void Atirar()
        {
            base.Atirar();
            Console.WriteLine("[causando Dano de Fogo continuo!]");
        }
    }
}