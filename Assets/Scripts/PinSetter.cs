using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public Text standingDisplay;
	
	void Update () 
	{
        standingDisplay.text = CountStanding().ToString();
	}

    private int CountStanding()
    {
        int pinCount = 0;
        // Currently being called every frame from update.
        // Move FindObjectsOfType to be only called once in future.
        foreach(Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                pinCount++;
            }
        }
        return pinCount;
    }
}
