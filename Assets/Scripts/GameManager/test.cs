using System.Collections;
using UnityEngine;

public class test : MonoBehaviour
{

    private Transform cameraTransform;
    [SerializeField] private Transform Canvas01;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = FindObjectOfType<Camera>().transform;
    }

    public void moveToNextScene()
    {
        StartCoroutine(delayCameraMovement());
    }

    IEnumerator delayCameraMovement()
    {
        while (cameraTransform.position.x < 22f)
        {
            float xPos = cameraTransform.position.x + 1f;
            cameraTransform.position = new Vector3(xPos, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }

}
