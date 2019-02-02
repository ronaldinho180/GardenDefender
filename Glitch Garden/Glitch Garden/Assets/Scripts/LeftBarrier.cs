using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeftBarrier : MonoBehaviour
{

    [SerializeField] private float waitTimeOne = 0.5f;
    [SerializeField] private float waitTimeTwo = 0.8f;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        StartCoroutine(GameOverSequence());
        
    }

    IEnumerator GameOverSequence()
    {
        yield return new WaitForSeconds(waitTimeOne);
        ScreamSound audio = FindObjectOfType<ScreamSound>();
        if (!audio.GetComponent<AudioSource>().isPlaying)
        {
           audio.GetComponent<AudioSource>().Play(); 
        }
        
        yield return new WaitForSeconds(waitTimeTwo);
        SceneManager.LoadScene("Game Over");
    }
}
