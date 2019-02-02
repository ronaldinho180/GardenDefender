using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour
{

    [SerializeField] private AxeProjectile axeProjectile;
    [SerializeField] private float pointOfFire = 0.3f;
    [SerializeField] private int starCost = 200;

    public void FireAxe()
    {
        AxeProjectile projectile = Instantiate(axeProjectile, new Vector2(transform.position.x + pointOfFire, transform.position.y), Quaternion.identity);
        projectile.transform.SetParent(this.transform);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
