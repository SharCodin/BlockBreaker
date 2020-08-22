using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int blockCount = 0;
    private int score = 0;
    private TextMeshProUGUI currentScore;
    private PauseMenu pauseMenu;

    // Assigned in inspector
    [SerializeField] private GameObject scoreText = null;

    // Awake
    private void Awake()
    {
        // Implementing Singleton pattern to force score to persist through levels
        // Singleton pattern - there can only be one.

        // Get the number of GameManager objects in the scene.
        int gameManagerCount = FindObjectsOfType<GameManager>().Length;

        // Check if there are multiple instances of the object, destroy if yes. 
        // Force object to persist when loading next scene.
        if (gameManagerCount > 1)
        {
            // Change gameObject to inactive to prevent attached scripts from running and to prevent scripts that refer to this from running.
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start
    private void Start()
    {
        // Cached Reference to score text
        currentScore = scoreText.GetComponent<TextMeshProUGUI>();
        pauseMenu = FindObjectOfType<PauseMenu>();

        // Initializing score
        UpdateScoreUI();
    }

    // Count number of blocks
    public void CountBrick()
    {
        blockCount += 1;
    }

    // Update block count and score
    public void Score()
    {
        blockCount -= 1;
        score += 1;
    }

    // Update the score on screen.
    public void UpdateScoreUI()
    {
        currentScore.text = score.ToString();
    }

    // Check if game has ended in win.
    public void GameWin()
    {
        if (blockCount <= 0)
        {
            // Current room beat
            pauseMenu.startWaitForLevelComplete();
        }
    }

    // Getter for brickCount
    public int getBrickCount()
    {
        return blockCount;
    }
}
