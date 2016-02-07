using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinCounter : MonoBehaviour 
{
    public Text standingDisplay;
    private int initialPinsStanding = 10;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        standingDisplay.text = CountStanding().ToString();
    }

    public void Reset()
    {
        initialPinsStanding = 10;
    }

    public int CountStanding()
    {
        int pinCount = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pinCount++;
            }
        }
        return pinCount;
    }

    void PinsSettled()
    {
        int standingPins = CountStanding();
        int pinFall = initialPinsStanding - standingPins;
        initialPinsStanding = standingPins;
        standingDisplay.color = Color.green;
        gameManager.Bowl(pinFall);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Ball>())
        {
            standingDisplay.color = Color.red;
            Invoke("PinsSettled", 3f);
        }
    }
}
