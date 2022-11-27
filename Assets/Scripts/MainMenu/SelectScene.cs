using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class SelectScene : MonoBehaviour
    {
        public void MetroStart() => SceneManager.LoadScene(1);
        public void ShipBattleStart() => SceneManager.LoadScene(2);
    }
}
