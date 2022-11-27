using BattleShips.Classes;
using BattleShips.Interfaces;

namespace BattleShips.Modules
{
    public class ModuleC : IModule, IWeaponCooldown
    {
        public int WeaponCooldown => 20;
        public string PathToIcon => "moduleC";

        public void TurnOnModule(BaseShip ship)
        {
            ship.WeaponCooldownReduce -= WeaponCooldown;
        }
        public void TurnOffModule(BaseShip ship)
        {
            ship.ShieldRechargeIncrease += WeaponCooldown;
        }
    }
}

