using BattleShips.Classes;

namespace BattleShips.Interfaces
{
    public interface IModule : IPath
    {
        public void TurnOnModule(BaseShip ship);
        public void TurnOffModule(BaseShip ship);
    }
}
