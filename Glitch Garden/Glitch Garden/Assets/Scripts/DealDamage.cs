using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int zucchiciDamage = 100;
    [SerializeField] private int axeDamage = 200;
    [SerializeField] private int ballDamage = 150;

    public int GetZucchiniDamage()
    {
        return zucchiciDamage;
    }

    public int GetAxeDamage()
    {
        return axeDamage;
    }

    public int GetBallDamage()
    {
        return ballDamage;
    }
}
