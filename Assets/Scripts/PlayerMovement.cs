using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float playerMoveSpeed = 15f;
    public float playerJumpForce = 10f;
    [SerializeField] float playerCameraRotationSpeed = 0.1f;
    private Rigidbody playerRigidBody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerRigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        processMovement();
        processPlayerJump();
        processCameraRotation();
    }

    void processMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        Transform cameraTransform = Camera.main.transform;

        if (Keyboard.current.wKey.isPressed)
        {
            moveDirection += new Vector3(cameraTransform.forward.x, 0, cameraTransform.forward.z);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            moveDirection += new Vector3(-cameraTransform.forward.x, 0, -cameraTransform.forward.z);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            moveDirection += new Vector3(-cameraTransform.right.x, 0, -cameraTransform.right.z);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveDirection += new Vector3(cameraTransform.right.x, 0, cameraTransform.right.z);
        }

        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
            transform.position += moveDirection * playerMoveSpeed * Time.deltaTime;
        }
    }

    void processCameraRotation()
    {
        if (Mouse.current.rightButton.isPressed)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();
            transform.Rotate(Vector3.up, mouseDelta.x * playerCameraRotationSpeed);
            Camera.main.transform.Rotate(Vector3.left, mouseDelta.y * playerCameraRotationSpeed * Time.deltaTime);
        }
    }

    void processPlayerJump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && playerIsGrounded())
        {
            playerRigidBody.AddForce(Vector3.up * playerJumpForce, ForceMode.Impulse);
        }
    }
    
    bool playerIsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
