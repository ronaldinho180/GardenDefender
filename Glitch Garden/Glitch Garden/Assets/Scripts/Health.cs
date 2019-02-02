using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] public int health;


    public void DoDamage(int attackAmount)
    {
        health -= attackAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
