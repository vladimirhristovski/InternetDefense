using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public float startHealth = 100;
    private float health;
    public int worth = 25;
    
    
    public GameObject deathEffect;
    
    [Header("Unity Stuff")]
    public Image healthBar;

    private bool isDead = false;

    void Start()
    {
        health = startHealth;
    }
    
    public void TakeDamage(float ammount)
    {
        health -= ammount;
        
        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        PlayerStats.Money += worth;

        WaveSpawner.EnemiesAlive--;
        WaveSpawner.EnemiesKilled++;
        
        Destroy(gameObject);
    }
}
