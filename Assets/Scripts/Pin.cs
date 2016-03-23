using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 10f;
    public float distanceToRaise = 0.4f;
    public PinSetter pinSetter;

    void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
    }

    public bool IsStanding()
    {
        if (Vector3.Angle(transform.up, Vector3.up) < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            GetComponent<Rigidbody>().useGravity = false;
            transform.Translate(Vector3.up * distanceToRaise);
            transform.rotation = Quaternion.identity;
        }
    }

    public void Lower()
    {
        transform.Translate(Vector3.down * pinSetter.distanceToRaise);
        GetComponent<Rigidbody>().useGravity = true;
    }
}
