using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarScore : MonoBehaviour
{
    private CheckScore toPlayParticle;
    private TextMeshProUGUI scoreText;
    private int score = 50;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        toPlayParticle = FindObjectOfType<CheckScore>();
    }

    void Update ()
	{
	    scoreText.text = GetScore().ToString();
	}

    public void AddToStarScore(int starScore)
    {
        toPlayParticle.PlayParticle();
        score += starScore;
        
    }

    public void SpendStars(int amount)
    {
        if (amount <= score)
        {
           score -= amount; 
        }
    }

    public int GetScore()
    {
        return score;
    }

    public bool EnoughStars(int amount)
    {
        return score >= amount;
    }


}
