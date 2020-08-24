using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollsionChecker : MonoBehaviour
{
    // Config and Params
    [SerializeField] private List<float> yPos = new List<float>();
    [SerializeField] private List<float> xPos = new List<float>();
    [SerializeField] private int[] possibleXValues = null;
    private Rigidbody2D rb;

    private void Start()
    {
        //Caching ball's rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if there are 4 recorded position
        if (yPos.Count < 4)
            yPos.Add(((float)System.Math.Round(transform.position.y, 1)));
        else
        {
            yPos.RemoveAt(0);
            yPos.Add(((float)System.Math.Round(transform.position.y, 1)));

            // Check if Position 1 is same as Position 3
            // If yes, infinite horizontal loop
            if (yPos[0] == yPos[2])
            {
                StartCoroutine(ResetGravityScale());
            }
        }

        // Check for vertical loop
        if (xPos.Count < 4)
        {
            xPos.Add(((float)System.Math.Round(transform.position.x, 1)));
        }
        else
        {
            xPos.RemoveAt(0);
            xPos.Add(((float)System.Math.Round(transform.position.x, 1)));

            // Check for infinite loop
            if (xPos[0] == xPos[2])
            {
                System.Random rdn = new System.Random();
                int choice = rdn.Next(0, possibleXValues.Length);
                rb.AddRelativeForce(new Vector2(choice, 0));
            }

        }
    }

    private IEnumerator ResetGravityScale()
    {
        rb.gravityScale = 1.0f;
        yield return new WaitForSeconds(0.2f);
        rb.gravityScale = 0.0f;
    }



}
