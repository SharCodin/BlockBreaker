using UnityEngine;

public class PadMovement : MonoBehaviour
{
    // Variables
    [SerializeField] float movementSpeed = 10.0f;
    private float leftBoundary = -8f;
    private float rightBoundary = 8f;

    // Update is called once per frame
    void Update()
    {
        PadMovementHorizontally();
    }

    // Pad movement in the x-axis
    private void PadMovementHorizontally()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftBoundary)
                transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightBoundary)
                transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
    }
}