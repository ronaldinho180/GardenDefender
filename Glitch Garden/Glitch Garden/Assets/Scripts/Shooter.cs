using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    SpawnEnemy myLaneSpawner;
    private Animator animator;

    // Use this for initialization
    void Start ()
	{
	    SetLaneSpawner();
	    animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (IsAttackerInLane())
	    {
	        animator.SetBool("IsAttacking", true);
	    }
	    else
	    {
	        animator.SetBool("IsAttacking", false);
	    }
	}

    private void SetLaneSpawner()
    {
        SpawnEnemy[] spawners = FindObjectsOfType<SpawnEnemy>();
        foreach(SpawnEnemy spawner in spawners)
        {
            bool inSameLane = (Mathf.Abs(Mathf.RoundToInt(spawner.transform.position.y) - Mathf.RoundToInt(transform.position.y)) <= Mathf.Epsilon);
            if (inSameLane)
            {
                myLaneSpawner = spawner;
            }
        }

        //return (myLaneSpawner.gameObject.transform.childCount >= 1) ? true : false;

    }

    private bool IsAttackerInLane()
    {
        return (myLaneSpawner.transform.childCount >= 1) ? true : false;
    }
}
