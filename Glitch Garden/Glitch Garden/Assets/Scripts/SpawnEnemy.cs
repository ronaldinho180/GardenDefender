using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private Attacker[] enemies;
    [SerializeField] private int randomNum;
    [SerializeField] private int randomMin = 1;
    [SerializeField] private int randomMax = 5;
    [SerializeField] public PlayerPrefsController controller;
    private int difficulty = 0;
    public float waitTime = 50f;
    private bool spawn = true;

	// Use this for initialization
	void Start ()
	{
	    difficulty = controller.GetDifficulty();
	    if (difficulty == 0)
	    {
	        randomMin = 7;
	        randomMax = 15;
	    }
        else if (difficulty == 1)
	    {
	        randomMin = 5;
	        randomMax = 11;
	    }
        else if (difficulty == 2)
	    {
	        randomMin = 2;
	        randomMax = 5;
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    CountDown();
        if (waitTime <= 0)
	    {
	        randomNum = Random.Range(randomMin, randomMax);
	        if (!FindObjectOfType<GameTimer>().timerFinished)
	        {
	            if (spawn)
	            {
	                spawn = false;
	                StartCoroutine(SpawnEnemies(randomNum));
	            }
	        }
	    }
	}

    IEnumerator SpawnEnemies(int seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        if (FindObjectOfType<GameTimer>().timerFinished)
        {
            yield break;
        }
        int randomSelection = Random.Range(0, enemies.Length);
        Attacker attacker = Instantiate(enemies[randomSelection], transform.position, Quaternion.identity);
        attacker.transform.SetParent(gameObject.transform);
        spawn = true;
        
    }

    void GetDifficulty()
    {
        SettingsMenu setting = new SettingsMenu();
        setting.SetDifficulty(setting.dropDown3.value);
        Debug.Log(setting.dropDown3.value);
    }

    void CountDown()
    {
        waitTime = waitTime - Time.deltaTime;
        //Debug.Log(waitTime);
    }
}
