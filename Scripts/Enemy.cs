using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class Enemy : MonoBehaviour
{

    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");
        FindObjectOfType<AudioManager>().Play("AlienDeath");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");

        animator.SetBool("IsDead", true);
        FindObjectOfType<AudioManager>().Play("AlienDeath");

        gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.15f;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
    
}
