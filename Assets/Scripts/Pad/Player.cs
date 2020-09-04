using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;

public class Player : MonoBehaviour
{
    // config params
    private PauseMenu pauseMenu;
    private Vector3 ballInitialPosition;
    private Vector3 paddleInitialPosition;
    
    private static int playerLifePoint = 5;

    [SerializeField] private TextMeshProUGUI playerLifeUI = null;
    [SerializeField] private Rigidbody2D ball = null;
    [SerializeField] private int playerLife; // For debugging

    private void Start()
    {
        // Initializing Debuggin variable
        playerLife = playerLifePoint;
        pauseMenu = FindObjectOfType<PauseMenu>();

        UpdatePlayerLifeUI();

        ballInitialPosition = ball.transform.position;
        paddleInitialPosition = transform.position;
    }

    private void UpdatePlayerLifeUI()
    {
        playerLifeUI.text = "Lives: " + playerLifePoint;
    }

    // Set the player life point
    public void SetPlayerLifePoint(int lp)
    {
        playerLifePoint = lp;
        playerLife = playerLifePoint;
        UpdatePlayerLifeUI();
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

        // Reset ball and paddle
        ball.velocity = new Vector2(0.0f, 0.0f);
        transform.position = paddleInitialPosition;
        ball.transform.position = ballInitialPosition;
        ball.GetComponent<BallMovement>().SetBallMovingBool();

        UpdatePlayerLifeUI();

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
        UpdatePlayerLifeUI();
    }

}