using UnityEngine;

public class LoseCollider : MonoBehaviour
{

    private Player currentPlayer;

    private void Start()
    {
        currentPlayer = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Lose");
            currentPlayer.LoseLife();
        }

    }


}
