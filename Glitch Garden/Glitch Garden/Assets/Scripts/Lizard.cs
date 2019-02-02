using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Shooter>() || otherObject.GetComponent<Trophy>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }
    }
}
