using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {
	Vector3 mousepos;
	// Use this for initialization
	void Start () {
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position =  Vector2.Lerp(transform.position, mousepos, 1000);

	}
}
