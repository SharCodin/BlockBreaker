using UnityEngine;

public class PadMovement : MonoBehaviour
{
    // Variables
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] private float leftBoundary = -8f;
    [SerializeField] private float rightBoundary = 8f;

    // Update is called once per frame
    void Update()
    {
        //PadMovementHorizontally();

        CheckForInput()
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

    public void PadMoveLeft()
    {
        if (transform.position.x > leftBoundary)
            transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
    }

    public void PadMoveRight()
    {
        if (transform.position.x < rightBoundary)
            transform.position = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }

    private void CheckForInput()
    {
        if(Input.GetMouseButton(0))
        {
            if (transform.position.x > leftBoundary)
                transform.position = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        }

    }


}