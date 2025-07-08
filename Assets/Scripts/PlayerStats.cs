using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    [SerializeField] private GameObject PlayerStatsUI;
    [SerializeField] private GameObject GameOverUI;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
        }
        if (PlayerStatsUI != null)
        {
            PlayerStatsUI.GetComponent<TextMeshProUGUI>().text = $"Health : {health}/{maxHealth}";
        }
        if (health <= 0)
        {
            InitiatePlayerDeath();
        }
    }

    private void InitiatePlayerDeath()
    {
        Debug.Log("Player has died.");
        if (GameOverUI != null)
        {
            GameOverUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("GameOverUI not found in the scene.");
        }
    }
}
