using UnityEngine;

public class Player : MonoBehaviour
{
    // config params
    private static int playerLifePoint = 3;
    private PauseMenu pauseMenu;
    
    [SerializeField] private int playerLife; // For debugging
    

    private void Start()
    {
        // Initializing Debuggin variable
        playerLife = playerLifePoint;
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    // Set the player life point
    public void SetPlayerLifePoint(int lp)
    {
        playerLifePoint = lp;
        playerLife = playerLifePoint;
    }

    // Get player life point
    public int GetPlayerLifePoint()
    {
        return playerLifePoint;
    }

    // Lose one life
    public void LoseLife()
    {
        playerLifePoint--;
        playerLife = playerLifePoint;
        if (playerLifePoint <= 0)
        {
            // Game Over
            pauseMenu.GameOver();
        }
    }

    // Gain one life
    public void GainLife()
    {
        playerLifePoint++;
        playerLife = playerLifePoint;
    }

}