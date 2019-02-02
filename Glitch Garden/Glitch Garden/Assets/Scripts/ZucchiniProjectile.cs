using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZucchiniProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;


    // Update is called once per frame
    void Update ()
	{
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
        //Destroy(gameObject);
    //}

}
