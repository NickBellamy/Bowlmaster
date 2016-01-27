using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public Text standingDisplay;

    private Ball ball;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
	
	void Update() 
	{
        standingDisplay.text = CountStanding().ToString();
	}

    private int CountStanding()
    {
        int pinCount = 0;
        foreach(Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pinCount++;
            }
        }
        return pinCount;
    }

    // When ball enters Pinsetter, update the UI and invoke SetScore
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Ball>())
        {
            standingDisplay.color = Color.red;
            Invoke("SetScore", 3f);
        }
    }

    void SetScore()
    {
        standingDisplay.color = Color.green;
        ball.Reset();
    }

    // Destroy pins when they leave the PinSetter box
    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Pin>())
        {
            Destroy(col.gameObject);
        }
    }
}
