using UnityEngine;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public float distanceToRaise = 0.4f;
    public GameObject pinSet;
    
    private Animator animator;
    private PinCounter pinCounter;

    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = FindObjectOfType<PinCounter>();

        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            pin.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void RaisePins()
    {
        foreach(Pin pin in FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
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
        pinCounter.Reset();
    }

    public void PerformAction(ActionMaster.Action result)
    {
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
    }
}
