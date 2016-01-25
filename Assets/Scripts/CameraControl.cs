using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public Ball ball;

    private Vector3 offset;

	void Start ()
    {
        offset = transform.position - ball.transform.position;
	}

    void Update()
    {
        if (transform.position.z <= 18.29)
        {
            transform.position = ball.transform.position + offset;
        }
    }
}
