using UnityEngine;

public class AreaOnTriggerEnter : MonoBehaviour
{
    public enum AreaType { EndGoal, Hazard, Checkpoint1 }
    public AreaType areaType;
    [SerializeField] private GameObject EndGoalUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (areaType == AreaType.EndGoal)
            {
                Debug.Log("You Win!");

                if (EndGoalUI != null)
                {
                    EndGoalUI.SetActive(true);
                }
                else
                {
                    Debug.LogWarning("EndGoalUI not found in the scene.");
                }
            }
            if (areaType == AreaType.Checkpoint1)
            {
                Debug.Log("Checkpoint Reached!");
                PlayerCheckpoint checkpoint = other.GetComponent<PlayerCheckpoint>();
                if (checkpoint != null)
                {
                    checkpoint.SetCheckpoint(new Vector3(-13.23588f, 21.69753f, -11.94822f));
                }
            }
            else if (areaType == AreaType.Hazard)
            {
                Debug.Log("Hazard Triggered!");
            }
        }
    }
}
