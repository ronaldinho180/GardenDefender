using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fox : MonoBehaviour
{

    [SerializeField] private float jumpSpeed = .3f;
    [SerializeField] private float hangTime = 0.8f;
    private bool isFoxInAir = false;

    void Update()
    {
        if (isFoxInAir)
        {
            transform.Translate(Vector2.left * Time.deltaTime * jumpSpeed);
        }
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetBool("jump", true);
            isFoxInAir = true;
            StartCoroutine(FoxJumping(hangTime));

        }
        else
        {
            GameObject otherObject = otherCollider.gameObject;
            if (otherObject.GetComponent<Shooter>() || otherObject.GetComponent<Trophy>())
            {
                GetComponent<Attacker>().Attack(otherObject);
            }
        }

    }

    IEnumerator FoxJumping(float secondsInAir)
    {
        yield return new WaitForSeconds(secondsInAir);
        isFoxInAir = false;
        GetComponent<Animator>().SetBool("jump", false);
    }
}
