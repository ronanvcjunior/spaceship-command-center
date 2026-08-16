namespace spaceship_command_center.src.Abstractions
{
    public abstract class ModificadorArma : IArma
    {
        protected readonly IArma _arma;
        public virtual string Nome { get; }

        protected ModificadorArma(IArma arma)
        {
            _arma = arma;
            Nome = _arma.Nome;
        }

        public virtual void Atirar() => _arma.Atirar();
    }
}