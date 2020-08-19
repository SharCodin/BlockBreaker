using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private int currentBuildIndex;
    private GameManager gameManager;

    // Assign in inspector
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject LevelCompleteMenu = null;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // Get current scene build index
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // Pause game on Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePause();
        }
    }

    // Display level complete and move to next level
    private IEnumerator waitForLevelComplete()
    {
        Time.timeScale = 0.0f;
        LevelCompleteMenu.SetActive(true);
        yield return new WaitForSecondsRealtime(1.5f);
        LevelCompleteMenu.SetActive(false);
        LoadNextScene();
        Time.timeScale = 1.0f;
    }

    // Start waitForLevelComplete coroutine
    public void startWaitForLevelComplete()
    {
        StartCoroutine(waitForLevelComplete());
    }

    // Pause and resume game
    private void GamePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0.0f;
            pauseMenu.SetActive(true);
            isPaused = true;
        }
    }

    // Change to next level as per build index
    private void LoadNextScene()
    {
        SceneManager.LoadScene(currentBuildIndex + 1);
    }

}
