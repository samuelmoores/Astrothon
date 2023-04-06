using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 5;

    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impactEffect, transform.position, transform.rotation);

        

        BossHealth bossHealth = hitInfo.GetComponent<BossHealth>();
        if (bossHealth != null)
        {
            bossHealth.TakeDamage(damage);
        }

        

        Destroy(gameObject);

        
        
    }



}
