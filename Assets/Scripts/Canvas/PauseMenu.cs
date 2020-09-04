using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    private int currentBuildIndex;
    private GameManager gameManager;


    // Assign in inspector
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private GameObject levelCompleteMenu = null;
    [SerializeField] private GameObject gameOver = null;
    [SerializeField] private Player playerPaddle = null;

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
    private IEnumerator WaitForLevelComplete()
    {

        levelCompleteMenu.GetComponentInChildren<TextMeshProUGUI>().text = 
            "Level " + SceneManager.GetActiveScene().buildIndex + " Completed" + "\n\n\n" + "Score: " + gameManager.GetCurrentScore().ToString();

        Time.timeScale = 0.0f;
        levelCompleteMenu.SetActive(true);
        yield return new WaitForSecondsRealtime(2.5f);
        levelCompleteMenu.SetActive(false);
        LoadNextScene();
        Time.timeScale = 1.0f;
    }

    private IEnumerator GameOverScreen()
    {
        Time.timeScale = 0.0f;

        gameOver.GetComponentInChildren<TextMeshProUGUI>().text = "GAME OVER" + "\n\n\n" + "Score: " + gameManager.GetCurrentScore().ToString();

        gameOver.SetActive(true);

        yield return new WaitForSecondsRealtime(3.0f);

        SceneManager.LoadScene("aTitleScreen");
       
        // Reset static variables: score, playerlives
        gameManager.SetScore();
        playerPaddle.SetPlayerLifePoint(3);

        Time.timeScale = 1.0f;
    }

    // Start waitForLevelComplete coroutine
    public void StartWaitForLevelComplete()
    {
        StartCoroutine(WaitForLevelComplete());
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

    // Game over menu
    public void GameOver()
    {
        StartCoroutine(GameOverScreen());
    }

}
