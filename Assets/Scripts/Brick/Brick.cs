using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int blockHealth = 3;
    [SerializeField] private Sprite[] blockSprites = null;
    private SpriteRenderer spriteRenderer;

    // Assign in inspector
    [SerializeField] private AudioClip audioClip = null;

    // Start of game
    private void Start()
    {
        // Cached Reference to Game Manager object
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Brick count.
        gameManager.CountBrick(GetBrickHealth());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Brick on collision with ball
        if (collision.collider.name.Equals("Ball"))
        {
            PlayBrickAudio();
            UpdateScore();

            // Check Brick lives
            blockHealth -= 1;
            if (blockHealth <= 0)
            {
                Destroy(gameObject);

                // Call GameWin and Load next scene when all blocks are destroyed.
                gameManager.GameWin();
            }
            else
            {
                int index = blockHealth - 1;
                spriteRenderer.sprite = blockSprites[index];
            }

        }
    }

    private void UpdateScore()
    {
        // Update Score
        gameManager.Score();
        gameManager.UpdateScoreUI();
    }

    private void PlayBrickAudio()
    {
        // Play music FX
        AudioSource.PlayClipAtPoint(audioClip, new Vector3(0, 0, -5));
    }

    private int GetBrickHealth()
    {
        return blockHealth;
    }
}