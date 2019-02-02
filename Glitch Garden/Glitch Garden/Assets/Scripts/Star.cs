using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Star : MonoBehaviour
{

    [SerializeField] private GameObject starParticle;
    [SerializeField] private GameObject starScore;
    [SerializeField] public float speed = 1.5f;
    [SerializeField] public int points = 50;
    private StarScore score;

    [Header("Constraints")]
    public float minYHeight;
    public float maxYHeight;

    private float posY;
    private TextMeshProUGUI energyScore;

    void Start()
    {
        score = FindObjectOfType<StarScore>();
        posY = Random.Range(minYHeight, maxYHeight);
        StarParticle();
    }

    void Update()
    {
        Vector2 endPos = new Vector2(transform.position.x, posY);
        LerpStarIntoPosition(endPos);
        //OnMouseDown();
    }

    void LerpStarIntoPosition(Vector2 endPosition)
    {
        transform.position = Vector3.Lerp(transform.position, endPosition, Time.deltaTime * speed);
    }

    void StarParticle()
    {
        GameObject shine = Instantiate(starParticle, transform.position, Quaternion.identity);
        shine.transform.SetParent(gameObject.transform);
       
    }

    void OnMouseDown()
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector2(starTransform.position.x, starTransform.position.y), Time.deltaTime * 100);
        score.AddToStarScore(points);
        Destroy(gameObject);
    }
}
