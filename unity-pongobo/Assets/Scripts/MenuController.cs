using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void PlayGame(string GameScene)
    {
        SceneManager.LoadScene(GameScene);
    }
}
