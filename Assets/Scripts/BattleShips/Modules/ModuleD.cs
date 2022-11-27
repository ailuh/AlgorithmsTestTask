using BattleShips.Classes;
using BattleShips.Interfaces;

namespace BattleShips.Modules
{
    public class ModuleD : IModule, IShieldRecovery
    {
        public float ShieldRecharge => 20f;
        public string PathToIcon => "moduleD";


        public void TurnOnModule(BaseShip ship)
        {
            ship.ShieldRechargeIncrease += ShieldRecharge;   
        }
    
        public void TurnOffModule(BaseShip ship)
        {
            ship.ShieldRechargeIncrease -= ShieldRecharge;   
        }
    }
}

