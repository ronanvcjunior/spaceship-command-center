namespace spaceship_command_center.src.Abstractions
{
    public interface  INave
    {
        IArma Arma { get; }
        void EquiparArma(IArma armamento);

        public void Atirar();
    }
}