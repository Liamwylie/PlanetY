using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {

	public int iAbilityChosen;
	public GameObject Blaster,Sniper,Grenade,Mine,Laser;
	private int iAmmo;
	private float fCooldown = 10.0f, fCurrentCooldown;
	public float bulletSpeed = 5.0f;
	Vector3 ShootDir;
	GameObject Projectile;

	
	void start() {
		switch(iAbilityChosen)
		{
			//blaster
		case 1:
			iAmmo = 10;
			break;
			//sniper
		case 2: 
			iAmmo = 6;
			break;
			//grenade launcher
		case 3: 
			iAmmo = 4;
			break;
			//mine
		case 4:
			iAmmo = 8;
			break;
			//Laser
		case 5:
			iAmmo = 3;
			break;
		}
	}

		
		
	void Update() {
		if(fCurrentCooldown <=0)
		{
			fCurrentCooldown = 0;
		if (Input.GetKeyDown ("e")) {
			switch(iAbilityChosen)
			{
			case 1:  
					ShootDir.x = 1;
					ShootDir.y = 0;
					ShootDir.z = 0;
				    Projectile = (GameObject)Instantiate(Blaster, transform.position, transform.rotation);
					fCurrentCooldown = 1.0f;
				break;
			case 2: 
					ShootDir = Input.mousePosition;
					ShootDir.z = 0;
					ShootDir = Camera.main.ScreenToWorldPoint(ShootDir);
					ShootDir = ShootDir-transform.position;
					Projectile = (GameObject)Instantiate(Sniper, transform.position, transform.rotation);
				break;
			case 3: print ("lel");
				break;
			case 4: print ("lel");
				break;
			case 5: print ("lel");
				break;
			}
			
			
		}

		}
		if(fCurrentCooldown > 0)fCurrentCooldown -= Time.deltaTime;
		if(Projectile != null)	Projectile.transform.position += new Vector3(ShootDir.x,ShootDir.y,ShootDir.z) * bulletSpeed * Time.deltaTime;
	}
}
