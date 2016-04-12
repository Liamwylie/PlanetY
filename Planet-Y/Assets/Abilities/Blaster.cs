using UnityEngine;
using System.Collections;



public class Blaster : MonoBehaviour {
	
    public Vector2 ShootDire;
    private float bulletSpeedy;

    // Use this for initialization
    void Start () {
		GameObject thePlayer = GameObject.Find ("Player");
		Abilities info = thePlayer.GetComponent<Abilities>();
        ShootDire = info.returnShootDir();
		this.GetComponent<Rigidbody2D> ().AddForce (ShootDire, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (bulletSpeedy);
		//if (ShootDire.x == 1)
   		//	 this.gameObject.transform.position += ShootDire * bulletSpeedy * Time.deltaTime;
		//if (ShootDire.x == -1)
			
    }
}
