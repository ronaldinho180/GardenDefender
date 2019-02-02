using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private GameObject victoryObject;
    [SerializeField] private float levelTime = 10;
    private SpawnEnemy spawn;
    private float secondsToWaitBeforeLoadingNextLevel = 5f;
    private float holdWaitTime = 0;
    public bool timerFinished = false;
	
	// Update is called once per frame
    void Start()
    {
        spawn = FindObjectOfType<SpawnEnemy>();
        holdWaitTime = spawn.waitTime;
    }

	void Update ()
	{
        
	    if (spawn.waitTime <= 0)
	    {
	        GetComponent<Slider>().value = (Time.timeSinceLevelLoad- holdWaitTime) / levelTime;

	        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
	        if (timerFinished)
	        {
	            if (!GameObject.FindWithTag("Fox") && !GameObject.FindWithTag("Lizard"))
	            {
	                victoryObject.SetActive(true);
	                WinAudio win = FindObjectOfType<WinAudio>();
	                if (!win.GetComponent<AudioSource>().isPlaying)
	                {
	                    win.GetComponent<AudioSource>().Play();
	                }
	                StartCoroutine(LoadNextLevel());
	            }
	        }
	    }
	}

    IEnumerator LoadNextLevel()
    {
        
        yield return new WaitForSeconds(secondsToWaitBeforeLoadingNextLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
