using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    private float waitTime = 0.5f;

    void Start()
    {
        StartCoroutine(PlayAudio());
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(waitTime);
        AudioSource audioSource = FindObjectOfType<AudioSource>();
        audioSource.Play();
    }
}
