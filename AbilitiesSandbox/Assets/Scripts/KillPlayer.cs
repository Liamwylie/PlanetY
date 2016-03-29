using UnityEngine;
using System.Collections;


public class KillPlayer : MonoBehaviour {

	public GameObject currentCheckpoint;
	public GameObject player;


	void OnTriggerEnter2D(Collider2D collider){
		if (collider.name == "Player") {
			player.transform.position =
				currentCheckpoint.transform.position;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
