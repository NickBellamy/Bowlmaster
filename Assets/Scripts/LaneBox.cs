using UnityEngine;
using System.Collections;

public class LaneBox : MonoBehaviour
{
    private PinSetter pinSetter;

    void Start()
    {
        pinSetter = FindObjectOfType<PinSetter>();
    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Ball>()){
            pinSetter.OutOfPlay();
        }   
    }
}
