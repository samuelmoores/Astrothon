using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class Weapon : MonoBehaviour
{

    public Transform firePoint;

    public GameObject bulletPrefab;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        animator.SetTrigger("Shoot");
        FindObjectOfType<AudioManager>().Play("PlayerShot");
    }

}
