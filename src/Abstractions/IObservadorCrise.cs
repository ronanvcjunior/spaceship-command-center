namespace spaceship_command_center.src.Abstractions
{
    /// <summary>
    /// Contrato para observadores que reagem a uma crise no núcleo (Observer Pattern).
    /// </summary>
    public interface IObservadorCrise
    {
        /// <summary>
        /// Método chamado automaticamente quando o núcleo entra em estado crítico.
        /// </summary>
        void ReagirACrise();
    }
}