using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public Text standingDisplay;
    public float distanceToRaise = 0.2f;

    private Ball ball;
    private Pin[] pins;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
    }
	
	void Update() 
	{
        standingDisplay.text = CountStanding().ToString();
	}

    public void RaisePins()
    {
        Debug.Log("Raising Pins");
        foreach(Pin pin in FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lowering Pins");
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing Pins");
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
