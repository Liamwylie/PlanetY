using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speedh = 5f, speedv = 1f, jumpheight = 1f;
	public string axisv = "Jump", axish = "Vertical";
	private Animator playerAnimator;
	private float movementSpeed = 0;
	private bool isJumping = false;
	private bool isGrounded;

	
	void Start () {
		isGrounded = false;
		playerAnimator = GetComponent<Animator> ();
	}

	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground") {
			isGrounded =true;
			isJumping = false;

		}

	}
	void FixedUpdate (){

		float v = Input.GetAxisRaw (axish);
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (v, 0) * speedh;
		movementSpeed = Mathf.Abs (Input.GetAxis ("Vertical"));

		if (Input.GetAxis ("Jump") != 0) {
			if(isGrounded)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, speedv);
			isGrounded=false;
				isJumping = true;


			}



		}
		Debug.LogError("jump bool "+ isJumping);
		Debug.LogError("Grounded bool "+ isGrounded);
		playerAnimator.SetBool  ("isJump",isJumping);
		playerAnimator.SetFloat ("Speed",movementSpeed);

	}
}
