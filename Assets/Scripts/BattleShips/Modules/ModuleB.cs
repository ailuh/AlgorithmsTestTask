using BattleShips.Classes;
using BattleShips.Interfaces;

namespace BattleShips.Modules
{
    public class ModuleB : IModule, IHealthValue
    {
        public float Health => 50;
        public string PathToIcon => "moduleB";

        public void TurnOnModule(BaseShip ship)
        {
            ship.HealthMax += Health;
        }

        public void TurnOffModule(BaseShip ship)
        {
            ship.HealthMax -= Health;
        }
    }
}

