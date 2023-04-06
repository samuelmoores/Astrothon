using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class BossHealth : MonoBehaviour
{
    public int health = 500;

    public BossComplete LevelLoader;

    public Animator anim;

    public GameObject completeBossUI;

    public HealthBarBoss bossHealthBar;

    public bool isHurt = false;

    private void Start()
    {
        completeBossUI.SetActive(false);
        bossHealthBar.SetMaxHealth(health);
    }

    public void CompleteBoss()
    {
        completeBossUI.SetActive(true);
    }

    public void TakeDamage(int damage)
    {

        if (isHurt)
            return;

        health -= damage;

        if (health <= 100)
        {
            GetComponent<Animator>().SetBool("isHurt", true);
        }

        FindObjectOfType<AudioManager>().Play("BossScream");

        bossHealthBar.SetHealth(health);

       

        if (health <= 0)
        {
            
            
            anim.SetBool("isDead", true);

            //anim.gameObject.GetComponent<Animator>().enabled = false;

            gameObject.GetComponent<Rigidbody2D>().gravityScale = -0.1f;

            CompleteBoss();
            
            LevelLoader.LoadNextLevel();

            //Destroy(gameObject);
        }
    }

}
