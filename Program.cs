using spaceship_command_center.src.Models;

var nucleo = new Nucleo(100, 20);
var escudo = new SistemaEscudo();
var iluminacao = new SistemaIluminacao();
var painel = new PainelNavegacao();

nucleo.AoEntrarEmCrise += escudo.ReagirACrise;
nucleo.AoEntrarEmCrise += iluminacao.ReagirACrise;
nucleo.AoEntrarEmCrise += painel.ReagirACrise;

nucleo.TomarDano(40);
nucleo.TomarDano(40);
nucleo.TomarDano(40);
