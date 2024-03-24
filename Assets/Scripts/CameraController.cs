using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5.0f;

    private bool movingLeft = false;
    private bool movingRight = false;

    public float minX = 0.4f;
    public float maxX = 18f;

    public void StartMovingLeft()
    {
        movingLeft = true;
    }

    public void StopMovingLeft()
    {
        movingLeft = false;
    }

    public void StartMovingRight()
    {
        movingRight = true;
    }

    public void StopMovingRight()
    {
        movingRight = false;
    }

    void Update()
    {
        if (movingLeft && transform.position.x > minX)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        }

        if (movingRight && transform.position.x < maxX)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        }
    }
}