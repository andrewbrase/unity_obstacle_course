using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private float timeToDrop = 5f;
    MeshRenderer objectMeshRenderer;
    Rigidbody objectRigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectMeshRenderer = GetComponent<MeshRenderer>();
        objectRigidBody = GetComponent<Rigidbody>();
        objectMeshRenderer.enabled = false;
        objectRigidBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToDrop && objectRigidBody.useGravity == false)
        {
            objectRigidBody.useGravity = true;
            objectMeshRenderer.enabled = true;
        }
    }
}
