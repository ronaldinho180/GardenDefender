using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{

    [SerializeField] private ZucchiniProjectile zucchiniProjectile;
    [SerializeField] private float pointOfFire = 0.5f;
    [SerializeField] private int starCost = 100;

    public void FireZucchini()
    {
        ZucchiniProjectile projectile = Instantiate(zucchiniProjectile, new Vector2(transform.position.x + pointOfFire, transform.position.y), Quaternion.identity);
        projectile.transform.SetParent(this.transform);
    }

    public int GetStarCost()
    {
        return starCost;
    }

}
