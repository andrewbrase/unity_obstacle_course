using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float spawnInterval = 1f;
    private bool spawnProjectiles = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnProjectiles = true;
            StartCoroutine(SpawnProjectiles());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnProjectiles = false;
            StopCoroutine(SpawnProjectiles());
        }
    }

    System.Collections.IEnumerator SpawnProjectiles()
    {
        while (spawnProjectiles)
        {
            if (projectilePrefab != null)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
            }
            else
            {
                Debug.LogWarning("projectilePrefab is null. Stopping projectile spawn.");
                yield break;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
