using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private int blockCount = 0;
    private static int score = 0;
    [SerializeField] private TextMeshProUGUI currentScore = null;
    private PauseMenu pauseMenu;

    // Start
    private void Start()
    {
        // Caching pauseMenu
        pauseMenu = FindObjectOfType<PauseMenu>();

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
            pauseMenu.StartWaitForLevelComplete();
        }
    }

    // Getter for brickCount
    public int getBrickCount()
    {
        return blockCount;
    }
}
