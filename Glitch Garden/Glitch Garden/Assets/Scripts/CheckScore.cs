using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckScore : MonoBehaviour {

    [SerializeField] private ParticleSystem scoreParticleEffect;
    //private ParticleSystem starSparkle;
    Animator animator;
    private StarScore score;
    private SpriteRenderer switchColour;
    [SerializeField] private float secondsToDestroyStarSparkle = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        score = FindObjectOfType<StarScore>();
        switchColour = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (score.GetScore() > 0)
        {
            switchColour.color = Color.white;
            score.GetComponent<TextMeshProUGUI>().color = new Color32(234, 245, 13, 255);
        }
        else
        {
           switchColour.color = new Color32(80, 80, 80, 255);
        }
    }

    public void PlayParticle()
    {
        animator.Play("StarScale");
        ParticleSystem starSparkle = Instantiate(scoreParticleEffect, transform.position, Quaternion.identity);
        starSparkle.transform.SetParent(gameObject.transform);
        Destroy(starSparkle.gameObject, 3f);
    }
    
}
