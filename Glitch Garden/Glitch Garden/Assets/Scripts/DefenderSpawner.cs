using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [Header("Defenders")]
    [SerializeField] private List<GameObject> defendersList;

    private GameObject placeDefender;
    [SerializeField] private DefenderParentHolder defenderParentHolder;
    

    [SerializeField] private float positionDefenders = 0.07f;
    [SerializeField] private float positionTrophy = 0.02f;

    private float positionOfX, positionOfY;

    private bool[,] gridSystem;

	// Use this for initialization
	void Start () {
	    gridSystem = new bool[,]
	    {
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false},
	        {false, false, false, false, false, false}
        };
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    public void SetSelectedDefender(GameObject selectedDefender)
    {
        placeDefender = selectedDefender;
    }

    private bool AttemptToPlaceDefenderAt()
    {
        var starDisplay = FindObjectOfType<StarScore>();
        foreach (var defender in defendersList)
        {
            if (placeDefender.tag == "Cactus" && defender.tag == "Cactus")
            {
                if (starDisplay.EnoughStars(FindObjectOfType<Cactus>().GetStarCost()))
                {
                    starDisplay.SpendStars(FindObjectOfType<Cactus>().GetStarCost());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (placeDefender.tag == "Scarecrow" && defender.tag == "Scarecrow")
            {
                if (starDisplay.EnoughStars(FindObjectOfType<Scarecrow>().GetStarCost()))
                {
                    starDisplay.SpendStars(FindObjectOfType<Scarecrow>().GetStarCost());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (placeDefender.tag == "Gnome" && defender.tag == "Gnome")
            {
                if (starDisplay.EnoughStars(FindObjectOfType<Gnome>().GetStarCost()))
                {
                    starDisplay.SpendStars(FindObjectOfType<Gnome>().GetStarCost());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (placeDefender.tag == "Gravestone" && defender.tag == "Gravestone")
            {
                if (starDisplay.EnoughStars(FindObjectOfType<Gravestone>().GetStarCost()))
                {
                    starDisplay.SpendStars(FindObjectOfType<Gravestone>().GetStarCost());
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (placeDefender.tag == "Trophy" && defender.tag == "Trophy")
            {
                if (starDisplay.EnoughStars(FindObjectOfType<Trophy>().GetStarCost()))
                {
                    starDisplay.SpendStars(FindObjectOfType<Trophy>().GetStarCost());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    void OnMouseUp()
    {
        Vector2 coordinates = GetWorldCoordinates();
        if (AttemptToPlaceDefenderAt())
        {
            if (gridSystem[(int) coordinates.x, (int) coordinates.y] == false)
            {
                if (placeDefender.tag == "Trophy")
                {
                    GameObject defenderGameObject = Instantiate(placeDefender, new Vector3(coordinates.x, coordinates.y - positionTrophy, 0),
                        Quaternion.identity);
                    defenderGameObject.transform.SetParent(defenderParentHolder.transform);
                }
                else
                {
                    GameObject defenderGameObject = Instantiate(placeDefender, new Vector3(coordinates.x, coordinates.y + positionDefenders, 0),
                        Quaternion.identity);
                    defenderGameObject.transform.SetParent(defenderParentHolder.transform);
                }

                gridSystem[(int) coordinates.x, (int) coordinates.y] = true;
            }
        }
    }

    Vector2 GetWorldCoordinates()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionOfX = Mathf.RoundToInt(worldPoint.x);
        positionOfY = Mathf.RoundToInt(worldPoint.y);

        return new Vector2(positionOfX, positionOfY);
    }
}
