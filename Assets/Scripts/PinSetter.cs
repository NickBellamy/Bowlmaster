using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public Text standingDisplay;

    private bool ballEnteredBox = false;
	
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

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Ball>())
        {
            standingDisplay.color = Color.red;
            ballEnteredBox = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Pin>())
        {
            Destroy(col.gameObject);
        }
    }
}
