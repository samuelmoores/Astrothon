using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class Coin : MonoBehaviour
{
    public int coinValue = 1;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CoinSound");

            ScoreManager.instance.ChangeScore(coinValue);

            Destroy(gameObject);
        }
    }
}
