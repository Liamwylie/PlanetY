using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {

	public int iAbilityChosen;
	public GameObject Blaster,Sniper,Grenade,Mine,Laser;
	private int iAmmo;
	private float fCooldown = 10.0f, fCurrentCooldown;
	private float bulletSpeed;
	Vector2 ShootDir;
	GameObject Projectile;

    public Vector3 returnShootDir()
    {
        return ShootDir;
    }

    public float returnBulletSpeed()
    {
        return bulletSpeed;
    }


    void shootblaster()
    {
        Projectile = (GameObject)Instantiate(Blaster, transform.position, transform.rotation);
       
    }


	void start() {
		ShootDir.x = 50;
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
        if (Input.GetKeyDown ("d")) {
			ShootDir.x = 50;
			Debug.Log (ShootDir.x);
		}
        if (Input.GetKeyDown ("a")) {
			ShootDir.x = -50;
			Debug.Log (ShootDir.x);
		}
        if (fCurrentCooldown <=0)
		{
			fCurrentCooldown = 0;
		if (Input.GetKeyDown ("e")) {
			switch(iAbilityChosen)
			{
			case 1:
                        shootblaster();
                        fCurrentCooldown = 1.0f;
                        break;
			case 2: 
					ShootDir = Input.mousePosition;
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

    }
}
