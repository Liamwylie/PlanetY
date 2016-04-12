using UnityEngine;
using System.Collections;



public class Blaster : MonoBehaviour {

    public Abilities info;
    Vector3 ShootDire;
    private float bulletSpeedy;

    // Use this for initialization
    void Start () {
        ShootDire = info.returnShootDir();
        bulletSpeedy = info.returnBulletSpeed();
	}
	
	// Update is called once per frame
	void Update () {
    this.gameObject.transform.position += new Vector3(ShootDire.x, ShootDire.y, ShootDire.z) * bulletSpeedy * Time.deltaTime;
    }
}
