using UnityEngine;

public class CubeRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 2.5f;
    
    void Update()
    {
        transform.Rotate(new Vector3(15, 0, 0) * Time.deltaTime * rotationSpeed);
    }
}
