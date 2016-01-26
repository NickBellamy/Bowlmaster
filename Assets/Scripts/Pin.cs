using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour 
{
    public float standingThreshold = 3f;
	
	public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltX = Mathf.Abs(rotationInEuler.x);
        float tiltZ = Mathf.Abs(rotationInEuler.z);

        if (tiltX < standingThreshold || tiltZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
