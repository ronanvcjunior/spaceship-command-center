using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Decorators
{
    /// <summary>
    /// Decorator concreto que adiciona efeito de perfuração de blindagem ao disparo da arma decorada.
    /// </summary>
    public class ModificadorPerfuracao(IArma arma) : ModificadorArma(arma)
    {
        /// <summary>
        /// Nome da arma decorada com o sufixo "Perfuração".
        /// </summary>
        public override string Nome => base.Nome + " Perfuração";

        /// <summary>
        /// Executa o disparo original e adiciona o efeito de perfuração de blindagem.
        /// </summary>
        public override void Atirar()
        {
            base.Atirar();
            Console.WriteLine("[derretendo a Blindagem inimiga!]");
        }
    }
}