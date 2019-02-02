using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{

    [SerializeField] private int amount;
    [SerializeField] private int starCost = 50;

    public void AddStar(int amount)
    {
        FindObjectOfType<StarScore>().AddToStarScore(amount);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
