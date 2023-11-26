using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    public int enemyShotDamage;
    public Health playerHealth;
    public Health enemyHealth;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        playerHealth = player.GetComponent<Health>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            enemyHealth.TakeDamage(enemyShotDamage);
            Destroy(collision.gameObject);
        }
    }
}
