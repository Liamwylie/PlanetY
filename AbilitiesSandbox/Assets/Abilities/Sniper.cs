using UnityEngine;
using System.Collections;

public class Sniper : MonoBehaviour {
	Vector3 mousepos;
	// Use this for initialization
	void Start () {
		mousepos = new Vector3 (Input.mousePosition.x,Input.mousePosition.y,0);	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, mousepos, 5.0f *Time.deltaTime);
	}
}
	