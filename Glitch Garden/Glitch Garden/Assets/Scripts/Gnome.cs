using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : MonoBehaviour {

    [SerializeField] private BallProjectile ballProjectile;
    [SerializeField] private float pointOfFire = 0.5f;
    [SerializeField] private int starCost = 150;

    public void FireBall()
    {
        BallProjectile projectile = Instantiate(ballProjectile, new Vector2(transform.position.x + pointOfFire, transform.position.y), Quaternion.identity);
        projectile.transform.SetParent(this.transform);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
