using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float playerJumpForce = 10f;
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
    }

    void processMovement()
    {
        Vector3 moveDirection = Vector3.zero;
        if (Keyboard.current.wKey.isPressed)
        {
            moveDirection += Vector3.forward;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            moveDirection += Vector3.back;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            moveDirection += Vector3.left;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            moveDirection += Vector3.right;
        }
        if (moveDirection != Vector3.zero)
        {
            moveDirection.Normalize();
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
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
