﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjectile : MonoBehaviour {

    [SerializeField] private float projectileSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(projectileSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
