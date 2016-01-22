using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public Vector3 launchVelocity;

    private AudioSource audioSource;
    private Rigidbody rigidBody;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();

        Launch();
	}

    public void Launch()
    {
        rigidBody.velocity = launchVelocity;
        audioSource.Play();
    }
}