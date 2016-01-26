using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 10f;

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
}
