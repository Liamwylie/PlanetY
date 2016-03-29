using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountScore : MonoBehaviour {

	public Text scoreText;
	public int scoreValue;
	public int winScore;

	// Use this for initialization
	void Start () {
		//Set the score to zero
		scoreValue = 0;
		UpdateScoreText ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Alter the score
	public void UpdateScoreValue (int scoreUpdate){
		//Update the score
		scoreValue += scoreUpdate;

		//Update the text of the score in the UI
		UpdateScoreText ();

	}

	//Update the score in the game
	void UpdateScoreText (){
		scoreText.text = "Score: " + scoreValue;
	}

	//Reset score to zero
	void ResetScore (){
		scoreValue = 0;
		UpdateScoreText();
	}


}
