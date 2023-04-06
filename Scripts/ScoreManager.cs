using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text text;
    int score;


    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString();
    }
}
