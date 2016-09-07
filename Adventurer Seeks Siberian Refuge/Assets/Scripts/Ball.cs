using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float ballInitVel = 600f;
	private Rigidbody rb;
	private bool ballActive;

	void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Fire1") && !ballActive) {
			transform.parent = null;
			ballActive = true;
			rb.isKinematic = false;
			rb.AddForce (new Vector3 (ballInitVel, ballInitVel, 0));
		}
	}
}