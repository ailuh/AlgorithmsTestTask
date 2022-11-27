using BattleShips.Classes;
using BattleShips.Interfaces;

namespace BattleShips.Modules
{
    public class ModuleA : IModule, IShieldValue
    {
        public float Shield => 50;

        public string PathToIcon => "moduleA";

        public void TurnOnModule(BaseShip ship)
        {
            ship.ShieldMax += Shield;   
        }
    
        public void TurnOffModule(BaseShip ship)
        {
            ship.ShieldMax -= Shield;   
        }
    }
}

