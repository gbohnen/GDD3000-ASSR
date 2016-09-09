using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public float paddleSpeed= 1f;

	Vector3 playerPos = new Vector3(0, -9.5f, 0);

	void Awake()
	{
		Vector3 newSize = transform.localScale;
		newSize.x *= GameManager.paddleStrech;
		transform.localScale = newSize;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// get the current x position of the paddle, and add the input value
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed * GameManager.paddleMod);
		playerPos = new Vector3 ((float)Mathf.Clamp (xPos, -8, 8), -9.5f, 0);
		transform.position = playerPos;
	}
}
