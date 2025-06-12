using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float cubeMoveSpeed = 2f;
    public float cubeMoveHeight = 5f;
    private float cubeInitialY;
    private float timeOffset;

    void Start()
    {
        cubeInitialY = transform.position.y;
        timeOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Calculate the new Y position using PingPong for smooth up and down movement
        float newY = cubeInitialY + Mathf.PingPong((Time.time + timeOffset) * cubeMoveSpeed, cubeMoveHeight);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
