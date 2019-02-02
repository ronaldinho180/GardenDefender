using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master volume";
    private const string DIFFICULTY_KEY = "difficulty";

    private const float MIN_VOLUME = 0;
    private const float MAX_VOLUME = 1;

    public static void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
        {
            Debug.LogError("Master volume is out of range!");
        }
    }

    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        //Debug.Log(difficulty);
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }


}
