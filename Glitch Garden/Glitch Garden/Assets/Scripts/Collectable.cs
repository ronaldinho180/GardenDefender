using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject starPrefab;

    [Header("Constraints")]
    public float minXWidth;
    public float maxXWidth;

    [Header("Wait Time")]
    public float minTimeToWait;
    public float maxTimeToWait;
    public float waitTime;

    private float posX;

    // Use this for initialization
    void Start()
    {
        waitTime = Random.Range(minTimeToWait, maxTimeToWait);
        posX = Random.Range(minXWidth, maxXWidth);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            Instantiate(starPrefab, new Vector2(posX, transform.position.y), Quaternion.identity);
            waitTime = Random.Range(minTimeToWait, maxTimeToWait);
            posX = Random.Range(minXWidth, maxXWidth);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
       
    }

}
