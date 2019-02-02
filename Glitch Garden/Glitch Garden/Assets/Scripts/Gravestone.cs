using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour {

    [SerializeField] private int starCost = 120;

    public int GetStarCost()
    {
        return starCost;
    }
}
