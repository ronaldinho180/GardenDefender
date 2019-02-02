using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range (0.25f, 5.0f)][SerializeField] private float currentSpeed = 1.0f;
    //[Range (0.25f, 5.0f)][SerializeField] private float currentSpeedFox = 1.0f;
    
    [SerializeField] private float secondsToWait = 0.85f;
    [SerializeField] private float colorChangeSecondsWait = 0.3f;
    [SerializeField] public int health = 300;
    [SerializeField] private int lizardHealth = 500;
    [SerializeField] private DealDamage damage;
    [SerializeField] private SpriteRenderer enemyBody;
    [SerializeField] private GameObject enemyBlood;
    [SerializeField] private float destroyDeathVFXTime = 1f;
    [SerializeField] private int damageAttack = 20;

    private HitSound hitSound;

    private GameObject currentTarget;

    private float tempSpeedHolder;

    // Use this for initialization
    void Start () {
	    if (gameObject.tag == "Lizard")
	    {
	        health = lizardHealth;
	    }
        tempSpeedHolder = currentSpeed;

    }
	
	// Update is called once per frame
	void Update ()
	{
        StartCoroutine(Walk(secondsToWait));
	}

    IEnumerator Walk(float seconds)
    {
        if (gameObject.tag == "Lizard")
        {
            yield return new WaitForSeconds(seconds);
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime); 
        }
        if (gameObject.tag == "Fox")
        {
            yield return new WaitForSeconds(seconds);
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Zucchini")
        {
            StartCoroutine(ShowHitRed(colorChangeSecondsWait));
            health -= damage.GetZucchiniDamage();
            hitSound = FindObjectOfType<HitSound>();
            hitSound.GetComponent<AudioSource>().Play();
            Destroy(col.transform.parent.gameObject);
        }
        else if (col.tag == "Axe")
        {
            StartCoroutine(ShowHitRed(colorChangeSecondsWait));
            health -= damage.GetAxeDamage();
            hitSound = FindObjectOfType<HitSound>();
            hitSound.GetComponent<AudioSource>().Play();
            Destroy(col.transform.parent.gameObject);
        }
        else if (col.tag == "Ball")
        {
            StartCoroutine(ShowHitRed(colorChangeSecondsWait));
            health -= damage.GetBallDamage();
            hitSound = FindObjectOfType<HitSound>();
            hitSound.GetComponent<AudioSource>().Play();
            Destroy(col.transform.parent.gameObject);
        }
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    IEnumerator ShowHitRed(float seconds)
    {
        enemyBody.color = Color.red;
        yield return new WaitForSeconds(seconds);
        enemyBody.color = Color.white;
    }

    void TriggerDeathVFX()
    {
        GameObject deathVFX = Instantiate(enemyBlood, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
        //deathVFX.transform.SetParent(this.transform);
        Destroy(deathVFX, destroyDeathVFXTime);
    }

    public void StopFromWalkingToAttack()
    {
        tempSpeedHolder = currentSpeed;
        currentSpeed = 0;
    }

    public void StartWalk()
    {
        currentSpeed = tempSpeedHolder;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
        StopFromWalkingToAttack();
    }

    //Need to add Health script to defenders
    public void StrikeCurrentTarget()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            StartWalk();
            return;
        }
        Health health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DoDamage(damageAttack);
        }
        if(health.health <= 0)
        {
            GetComponent<Animator>().SetBool("IsAttacking", false);
            StartWalk();
        }
        

    }
}
