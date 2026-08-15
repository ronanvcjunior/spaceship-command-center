using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spaceship_command_center.src.Abstractions
{
    public interface  IComando
    {
        void Executar(string[] args);
    }
}