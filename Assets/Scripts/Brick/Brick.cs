using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameManager gameManager;

    // Assign in inspector
    [SerializeField] private AudioClip audioClip = null;

    // Start of game
    private void Start()
    {
        // Cached Reference to Game Manager object
        gameManager = FindObjectOfType<GameManager>();

        // Brick count.
        gameManager.CountBrick();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Brick on collision with ball
        if (collision.collider.name.Equals("Ball"))
        {
            // Play music FX
            AudioSource.PlayClipAtPoint(audioClip, new Vector3(0, 0, -5));

            // Update Score
            gameManager.Score();
            gameManager.UpdateScoreUI();

            // Destroy brick
            Destroy(gameObject);

            // Call GameWin and Load next scene when all blocks are destroyed.
            gameManager.GameWin();
        }
    }
}
