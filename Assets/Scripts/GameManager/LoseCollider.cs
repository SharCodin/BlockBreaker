using UnityEngine;

public class LoseCollider : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
            Debug.Log("Lose");
    }


}
