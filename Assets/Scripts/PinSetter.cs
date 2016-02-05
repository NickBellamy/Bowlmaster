using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public Text standingDisplay;
    public float distanceToRaise = 0.4f;
    public GameObject pinSet;

    private Ball ball;
    private int initialPinsStanding = 10;
    private Animator animator;
    private ActionMaster actionMaster = new ActionMaster();

    void Start()
    {
        animator = GetComponent<Animator>();
        ball = FindObjectOfType<Ball>();

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.GetComponent<Rigidbody>().useGravity = true;
        }
    }
	
	void Update() 
	{
        standingDisplay.text = CountStanding().ToString();
	}

    public void RaisePins()
    {
        foreach(Pin pin in FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
            pin.transform.rotation = Quaternion.identity;
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        Instantiate(pinSet, new Vector3(0, distanceToRaise, 18.29f), Quaternion.identity);
        initialPinsStanding = 10;
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

    // When ball exits Pinsetter, update the UI and invoke SetScore
    public void OutOfPlay()
    {
        standingDisplay.color = Color.red;
        Invoke("SetScore", 3f);
    }

    void SetScore()
    {
        int standingPins = CountStanding();
        ActionMaster.Action result = actionMaster.Bowl(initialPinsStanding - standingPins);
        Debug.Log("Pinfall: " + (initialPinsStanding - standingPins) + " " + result);
        if (result == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (result == ActionMaster.Action.EndTurn || result == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
        }
        // TODO: Need to write the code to handle this!
        else if (result == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Not sure how to handle this yet!");
        }
        initialPinsStanding = standingPins;
        standingDisplay.color = Color.green;
        ball.Reset();
    }
}
