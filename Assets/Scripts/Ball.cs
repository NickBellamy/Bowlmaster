using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public Vector3 launchVelocity;
    public bool inPlay = false;

    private AudioSource audioSource;
    private Rigidbody rigidBody;

	void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();

        rigidBody.useGravity = false;
	}

    public void Launch(Vector3 velocity)
    {
        inPlay = true;
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource.Play();
    }
}