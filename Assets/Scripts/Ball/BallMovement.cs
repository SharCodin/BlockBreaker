using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float ballSpeed = 5.0f;
    [SerializeField] private bool ballMoving = false;
    [SerializeField] private Transform padPosition = null;

    private static bool isPlayTest = false;

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

        // for play testing game from start.
        if (Input.GetKeyDown(KeyCode.F9))
            isPlayTest = true;

        if (isPlayTest && !ballMoving)
        {
            rb.velocity = new Vector2(1, 15);
            ballMoving = true;
        }

    }

    private void FixedUpdate()
    {
        if (!ballMoving)
        {
            BallGluePaddle();
        }

        if (isPlayTest && ballMoving)
        {
            isPlayTesting();
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

    public void SetBallMovingBool()
    {
        ballMoving = false;
    }

    private void isPlayTesting()
    {
        padPosition.position = new Vector3(transform.position.x + 0.35f,padPosition.position.y, padPosition.position.z);
    }

}