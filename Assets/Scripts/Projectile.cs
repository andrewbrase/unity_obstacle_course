using UnityEngine;
using UnityEngine.Rendering;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float durration = 5.0f;
    private Vector3 playerLocation;

    void Start()
    {
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform.position;
        Destroy(gameObject, durration);
    }

    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerLocation, step);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Projectile"))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Destroy(gameObject);
                    PlayerStats playerStats = other.gameObject.GetComponent<PlayerStats>();
                    if (playerStats != null)
                    {
                        playerStats.TakeDamage(10);
                    }
                    return;
                }
                Destroy(gameObject);
            }
    }
}
