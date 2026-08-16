using spaceship_command_center.src.Abstractions;
using spaceship_command_center.src.Strategies;

namespace spaceship_command_center.src.Models
{
    /// <summary>
    /// Representa a nave, responsável por gerenciar e disparar a arma equipada.
    /// </summary>
    public class Nave : INave
    {
        /// <summary>
        /// Arma atualmente equipada. Começa desacoplada (<see cref="ArmaVazio"/>).
        /// </summary>
        public IArma Arma { get; private set; } = new ArmaVazio();

        /// <summary>
        /// Substitui a arma equipada pela informada.
        /// </summary>
        /// <param name="arma">Nova arma (ou decorator de arma) a ser equipada.</param>
        public void EquiparArma(IArma arma)
        {
            Arma = arma;
            Console.WriteLine($"[Nave] {Arma.Nome} equipado(a) com sucesso.");
        }

        /// <summary>
        /// Executa o disparo utilizando a arma atualmente equipada.
        /// </summary>
        public void Atirar() => Arma.Atirar();
    }
}