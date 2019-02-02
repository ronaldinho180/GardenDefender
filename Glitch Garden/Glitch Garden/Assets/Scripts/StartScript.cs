using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float seconds = 3.0f;

    void Update()
    {
        StartCoroutine(LoopAudio(seconds));
    }

    private IEnumerator LoopAudio(float secondsToWait)
    {
        if (!audioSource.isPlaying)
        {
            yield return new WaitForSeconds(secondsToWait);
            audioSource.Play();
        }
    }

}
