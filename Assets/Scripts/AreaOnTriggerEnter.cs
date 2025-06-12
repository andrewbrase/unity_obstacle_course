using UnityEngine;

public class AreaOnTriggerEnter : MonoBehaviour
{
    public enum AreaType { EndGoal, Hazard }
    public AreaType areaType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (areaType == AreaType.EndGoal)
            {
                Debug.Log("You Win!");
            }
            else if (areaType == AreaType.Hazard)
            {
                Debug.Log("Hazard Triggered!");
            }
        }
    }
}
