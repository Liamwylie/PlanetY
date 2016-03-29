using UnityEngine;
using System.Collections;

public class ScoreTrigger : MonoBehaviour {

	public CountScore cs;
	public BallMovement bm;

	//Check if ball is over the line and update score value
	void OnTriggerEnter2D (Collider2D Other){
		Debug.Log ("Ball crossed the line");
		Debug.Log (Other.tag);

		//Check to see if it is the ball that has passed the line
		if (Other.tag == "Ball") {
			cs.UpdateScoreValue (1);
		}
		Debug.Log (gameObject.name);

		//Trigger the ball either left or right
		if (gameObject.name == "RightScore"){
			bm.reset("Right");
		}
		else if (gameObject.name == "LeftScore"){
				bm.reset("Left");
		}
	
	}
}
