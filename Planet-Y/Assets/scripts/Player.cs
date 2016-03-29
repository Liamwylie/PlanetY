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
    public GameObject Cam; 
    public bool grounded = false;
    public bool ceilinged = false;
   // public bool MobAbi_TrippleJump = true;


    public char MobAbi_InUse;


    public float MobAbi_Cooldown;
    public bool MobAbi_Cooleddown = true;
    public float Timer;
    public float wait_time = 3.0f;
    public char KeyPressed;
    public bool playerReversed;
    GameObject ghost;
    private bool startTimer = false;
    public bool canMove = true;

    DistanceJoint2D joint;
    Vector3 grappleTargetPos;
    RaycastHit2D grappleHit;
    public float distance = 10.0f;
    public LayerMask mask;

    void Start()
    {
        //GameObject pData = GameObject.Find("Data");
        //Debug.Log(pData.GetComponent("pMob"));

        DataScript pData = FindObjectOfType(typeof(DataScript)) as DataScript;
        Debug.Log(pData.returnMob());

        speed = 7.5f;
        playerBody = this.GetComponent<Rigidbody2D>();
        playerTransform = this.GetComponent<Transform>();
        joint = this.GetComponent<DistanceJoint2D>();
        
        if (pData.returnMob() == 0){
            MobAbi_InUse = 'b';
            MobAbi_Cooldown = 15.0f;
            Debug.Log(pData.returnMob());
        }
        if (pData.returnMob() == 1){
            MobAbi_InUse = 'j';
            Debug.Log(pData.returnMob());
        }
        if (pData.returnMob() == 2){
            MobAbi_InUse = 't';
            MobAbi_Cooldown = 45.0f;
            Debug.Log(pData.returnMob());
        }
        if (pData.returnMob() == 3){
            MobAbi_InUse = 'g';
            MobAbi_Cooldown = 30.0f;
            Debug.Log(pData.returnMob());
        }
        
        Timer = wait_time;
    }

    void Update()
    {

        if (canMove)
        {
            Move(Input.GetAxisRaw("Horizontal"));
        }

        Cam.transform.position = playerBody.transform.position + new Vector3(0, 0, -10);

         

        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (MobAbi_Cooleddown)
            {
                MobAbi(MobAbi_InUse);
            }
        }


        if (Input.GetKey(KeyCode.A) && joint.enabled == true)
        {
            joint.distance -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && joint.enabled == true)
        {
            joint.distance += Time.deltaTime;
        }

        if (MobAbi_InUse == 'j')
        {
            //MobAbi_TrippleJump = true;
        }

        if (!MobAbi_Cooleddown)
        {
            MobAbi_Cooldown -= Time.deltaTime;
            Debug.Log("" + MobAbi_Cooldown);
        }
        if (MobAbi_Cooldown <= 0)
        {
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

        if (startTimer)
        {
            Timer -= Time.deltaTime;
            Debug.Log("" + Timer);
        }

        if (Timer <= 0)
        {
            startTimer = false;
            speed = 7.5f;
            Timer = wait_time;
        }

        if (Input.GetMouseButtonDown(0) && MobAbi_InUse == 't')
        {
            teleport();
        }

        if (Input.GetMouseButtonDown(1) && MobAbi_InUse == 't' && ghost != null)
        {
            teleportCancel();
        }

        if (Input.GetButtonDown("Jump") && MobAbi_InUse == 'g' && joint.enabled == true)
        {
            joint.enabled = false;
        }


    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" && !playerReversed)
        {
            if (MobAbi_InUse == 'j')
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

            if (MobAbi_InUse == 'j')
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

    void OnCollisionStay2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "L_Wall")
        {
            if (Input.GetKey(KeyCode.A))
            {

                playerBody.velocity -= 1.8f * Vector2.up;
            }
        }

        if (coll.gameObject.tag == "R_Wall")
        {

            if (Input.GetKey(KeyCode.D))
            {

                playerBody.velocity -= 1.8f * Vector2.up;
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

    public void RotateLeft()
    {
        playerTransform.transform.eulerAngles = new Vector2(0, 0);  
    }


    public void RotateRight()
    {
        playerTransform.transform.eulerAngles = new Vector2(0, 180);
    }


    public void jump()
    {
        if (jumps >= 1 && !playerReversed)
        {
            playerBody.velocity = JumpStrength * Vector2.up;
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
        if (ghost != null)
        {
            transform.position = ghost.transform.position;
            Destroy(ghost);
        }
    }

    public void teleportCancel()
    {
        if (ghost != null)
        {
            Destroy(ghost);
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
            
            MobAbi_Cooleddown = false;

            grappleTargetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            grappleTargetPos.z = 0;
            grappleHit = Physics2D.Raycast(transform.position, grappleTargetPos - transform.position, distance, mask);
            Debug.Log("1");
            if (grappleHit.collider != null && grappleHit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
            {
                
                joint.enabled = true;
                joint.connectedBody = grappleHit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.connectedAnchor = grappleHit.point = new Vector2(grappleHit.collider.transform.position.x, grappleHit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, grappleHit.point);
                Debug.Log("2");
            }
        }
    }
}