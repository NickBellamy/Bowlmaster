using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PinSetter : MonoBehaviour 
{
    public Text standingDisplay;
    public float distanceToRaise = 0.2f;
    public GameObject pinPrefab;

    private Ball ball;
    private Pin[] pins;

    void Start()
    {
        ball = FindObjectOfType<Ball>();
        pins = FindObjectsOfType<Pin>();
    }
	
	void Update() 
	{
        standingDisplay.text = CountStanding().ToString();
	}

    public void RaisePins()
    {
        Debug.Log("Raising Pins");
        foreach(Pin pin in pins)
        {
            if (pin.IsStanding())
            {
                pin.GetComponent<Rigidbody>().useGravity = false;
                pin.transform.position += new Vector3(0, distanceToRaise, 0);
            }
        }
    }

    public void LowerPins()
    {
        Debug.Log("Lowering Pins");
        foreach (Pin pin in pins)
        {
            if (pin.IsStanding())
            {
                pin.transform.position -= new Vector3(0, distanceToRaise, 0);
                pin.GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renewing Pins");
        Instantiate(pinPrefab, new Vector3(0, 0, 18.29f), Quaternion.identity);
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
