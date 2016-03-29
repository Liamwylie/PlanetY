using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{
	public float speed = 7.5f;
    public float JumpStrength = 10f;
    public int jumps = 2;
    Transform playerTransform;
    Rigidbody2D playerBody;
	public GameObject currentCheckpoint;
	public GameObject Teleport_Ghost;
	public bool grounded = false;
    public bool ceilinged = false;
    public bool MobAbi_TrippleJump = true;
    public char MobAbi_InUse = 'b';
    public float MobAbi_Cooldown;
    public bool MobAbi_Cooleddown = true;
	public float Timer; 
	public float wait_time = 3.0f;
    public char KeyPressed;
    public bool playerReversed;
	GameObject ghost;
	private bool startTimer = false;

	int x = 0;

    void Start()
    {
		speed = 7.5f;
        playerBody = this.GetComponent<Rigidbody2D>();
        playerTransform = this.GetComponent<Transform>();
        if (MobAbi_InUse == 'b')
        {
            MobAbi_Cooldown = 15.0f;
        }
        if (MobAbi_InUse == 't')
        {
            MobAbi_Cooldown = 45.0f;
        }
        if (MobAbi_InUse == 'g')
        {
            MobAbi_Cooldown = 30.0f;
        }
		Timer = wait_time;
    }

    void Update()
    {
        Move(Input.GetAxisRaw("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
        if (Input.GetKey(KeyCode.D))
        {
            KeyPressed = 'D';
        }
        else if (Input.GetKey(KeyCode.A))
        {
            KeyPressed = 'A';
        }
        else
        {
            KeyPressed = '/';
        }

        if (Input.GetKey(KeyCode.Q))
        {
			if (MobAbi_Cooleddown){
            MobAbi(MobAbi_InUse);
			}
        }

        if (MobAbi_InUse == 'j')
        {
            MobAbi_TrippleJump = true;
        }

		if (!MobAbi_Cooleddown) {
			MobAbi_Cooldown -= Time.deltaTime;
			Debug.Log (""+MobAbi_Cooldown);
		}
		if (MobAbi_Cooldown <= 0) {
			MobAbi_Cooleddown = true;
			if (MobAbi_InUse == 'b')
			{
				MobAbi_Cooldown = 15.0f;
			}
			if (MobAbi_InUse == 't')
			{
				MobAbi_Cooldown = 45.0f;
			}
			if (MobAbi_InUse == 'g')
			{
				MobAbi_Cooldown = 30.0f;
			}
		}

		if (startTimer) {
			Timer -= Time.deltaTime;
			Debug.Log (""+Timer);
		}

		if(Timer <= 0){
			startTimer = false;
			speed = 7.5f;
			Timer = wait_time;
		}

		if (Input.GetMouseButtonDown (0) && MobAbi_InUse == 't') {
			teleport();
		}

		if (Input.GetMouseButtonDown (1) && MobAbi_InUse == 't' && ghost != null) {
			teleportCancel();
		}
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" && !playerReversed)
        {
            if (MobAbi_TrippleJump)
            {
                jumps = 3;
            }
            else
            {
                jumps = 2;
            }

            grounded = true;
        }
        else
        {
            grounded = false;
        }

        if (coll.gameObject.tag == "Ceiling" && playerReversed)
        {
            
            if (MobAbi_TrippleJump)
            {
                jumps = 3;
            }
            else
            {
                jumps = 2;
            }
            grounded = false;
            ceilinged = true;
        }
    }

	void OnCollisionStay2D(Collision2D coll){

		if (coll.gameObject.tag == "L_Wall")
		{
			if (Input.GetKey(KeyCode.A))
			{
				
				playerBody.velocity -=  1.8f * Vector2.up;
				//transform.position = new Vector3(0,1,0)* -2.0f * Time.deltaTime;
			}
		}
		
		if (coll.gameObject.tag == "R_Wall")
		{
			
			if (Input.GetKey(KeyCode.D))
			{
				
				playerBody.velocity -=  1.8f * Vector2.up;
				//transform.position = new Vector3(0,1,0)* -2.0f * Time.deltaTime;
			}
		}
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "blueArea")
        {
            playerReversed = true;
            playerBody.gravityScale = -1;
        }

		if (coll.gameObject.tag == "Fatal")
		{
			playerBody.position = currentCheckpoint.transform.position;
			grounded = true;
		}

		if (coll.gameObject.tag == "blueArea")
		{
			playerReversed = false;
			playerBody.gravityScale = 3;
			JumpStrength *= -1;
		}
    }

	


    public void Move(float hInput)
    {
        Vector2 velocity = playerBody.velocity;
        velocity.x = hInput * speed;
        playerBody.velocity = velocity;
    }


    public void jump()
    {
        if (jumps >= 1 && !playerReversed)
        {
            playerBody.velocity = JumpStrength  * Vector2.up;
            jumps--;
        }
        if (jumps >= 1 && playerReversed)
        {
            playerBody.velocity = (JumpStrength * -1) * Vector2.up;
            jumps--;
        }

    }

	public void teleport()
	{
		if (ghost != null) {
			transform.position = ghost.transform.position;
			Destroy (ghost);
		}
	}

	public void teleportCancel()
	{
		if (ghost != null) {
			Destroy (ghost);
		}
	}

    public void MobAbi(char L_MobAbi_InUse)
    {
        if (L_MobAbi_InUse == 'b' && MobAbi_Cooleddown)
        {
            Timer = 3.0f;
			speed = 10.0f;
			MobAbi_Cooleddown = false;
			startTimer = true;
        }

        if (L_MobAbi_InUse == 't')
        {
            var mousePos = Input.mousePosition;
            var objectPos = Camera.main.ScreenToWorldPoint(mousePos);

			objectPos.z = 0;
			Timer = 10.0f;

			startTimer = true;
			MobAbi_Cooleddown = false;

			ghost = (GameObject)Instantiate(Teleport_Ghost, objectPos, Quaternion.identity);

        }
       
		if (L_MobAbi_InUse == 'g' && MobAbi_Cooleddown)
        {
            //Kill the programmers spirit
        }
    }
}