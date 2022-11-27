using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class ReturnToMain : MonoBehaviour
    {
        public void ReturnToMainScene() => SceneManager.LoadScene(0);
    }
}

