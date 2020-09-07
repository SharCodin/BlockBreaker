using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    private PauseMenu pauseMenu;
    private static int highScore = 0;
    private bool assistOnOffbool;

    [SerializeField] private int blockCount = 0;
    [SerializeField] private TextMeshProUGUI currentScore = null;

    // Start
    private void Start()
    {
        // Caching pauseMenu
        pauseMenu = FindObjectOfType<PauseMenu>();

        assistOnOffbool = FindObjectOfType<Assistance>().AssistedOnOff();

        // Initializing score
        UpdateScoreUI();

    }

    // Count number of blocks
    public void CountBrick(int blockNumber)
    {
        blockCount += blockNumber;
    }

    // Update block count and score
    public void Score()
    {

        blockCount -= 1;
        if (assistOnOffbool)
        {
            score += 1;
        }
        else
        {
            score += 2;
        }
        
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }

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
            pauseMenu.StartWaitForLevelComplete();
        }
    }

    // Getter for brickCount
    public int getBrickCount()
    {
        return blockCount;
    }

    public void SetScore()
    {
        score = 0;
    }

    public void SetHighScore(int aHighScore)
    {
        highScore = aHighScore;
    }

    public int GetCurrentScore()
    {
        return score;
    }

}
