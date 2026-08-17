using spaceship_command_center.src.Abstractions;

namespace spaceship_command_center.src.Invokers
{
    /// <summary>
    /// Representa a definição de um comando disponível no console.
    /// Contém a implementação do comando e sua descrição.
    /// </summary>
    /// <param name="Comando">Implementação do comando.</param>
    /// <param name="Descricao">Descrição apresentada ao usuário.</param>
    public record DefinicaoComando(IComando Comando, string Descricao);
}