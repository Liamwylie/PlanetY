using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	public float ballSpeed = 300f;
	private Rigidbody2D rgBall;
	private Vector2 defaultPos;

	// Use this for initialization
	void Start () {
		//Get the starting position of the ball
		defaultPos = transform.position;

		//Initial velocity of the ball
		rgBall = GetComponent<Rigidbody2D> ();
		rgBall.velocity = Vector2.right * ballSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Reset the ball to either the left or the right of the screen
	public void reset (string startPosition){
		transform.position = defaultPos;

		rgBall = GetComponent<Rigidbody2D> ();

		//Move the ball right
		if (startPosition == "Right") {
			rgBall.velocity = Vector2.right * ballSpeed;
		}

		//Move ball left
		if (startPosition == "Left") {
			rgBall.velocity = new Vector2(-1,0) * ballSpeed;
		}
	}
}
