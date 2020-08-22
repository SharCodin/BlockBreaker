using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Room001");
    }

    public void LevelSelector()
    {
        return;
    }

    public void Shop()
    {
        return;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
