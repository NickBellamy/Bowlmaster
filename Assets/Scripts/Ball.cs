using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Vector3 launchVelocity;
    public bool inPlay = false;

    private AudioSource audioSource;
    private Rigidbody rigidBody;
    private Vector3 startPosition;

	void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.useGravity = false;
        startPosition = transform.position;
	}

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = startPosition;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}