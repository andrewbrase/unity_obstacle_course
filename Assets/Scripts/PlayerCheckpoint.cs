using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject checkpointTextUI;
    private Vector3 checkpointPosition;
    private bool checkpointSet = false;

    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame && checkpointSet)
        {
            transform.position = checkpointPosition;
        }
    }

    public void SetCheckpoint(Vector3 newCheckpointPosition)
    {
        checkpointPosition = newCheckpointPosition;
        checkpointSet = true;
        if (checkpointTextUI != null)
        {
            checkpointTextUI.SetActive(true);
        }
    }
}
