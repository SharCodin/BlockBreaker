using UnityEngine;

public class BallMovement : MonoBehaviour
{

    [SerializeField] float ballSpeed = 5.0f;
    private Rigidbody2D rb;
    [SerializeField] private bool ballMoving = false;
    [SerializeField] Transform padPosition = null;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ballMoving)
        {
            BallStartMoving();
        }
    }

    private void FixedUpdate()
    {
        if (!ballMoving)
        {
            BallGluePaddle();
        }
    }

    // Start ball movement
    private void BallStartMoving()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, ballSpeed);
            ballMoving = true;
        }
    }

    // Position ball relative to pad
    private void BallGluePaddle()
    {

        transform.position = new Vector3(padPosition.position.x, transform.position.y, 0);
    }

}