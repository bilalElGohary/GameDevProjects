using UnityEngine;

public class PlayerMOVV2 : MonoBehaviour
{
// --- ALL VAR
    public float walkspeed = 10f; 
    public float runspeed = 4f;
    public float maxspeed = 20f;
    public float jumpforce = 5f;
    private float currspeed;
    private Rigidbody rb;
    private bool isground;

// --- ALL FUNC
    void Sprint() //retruns walkspeed multi. by runspeed if the player enter the keycode leftshift 
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currspeed = walkspeed * runspeed;
        }
        else
        {
            currspeed = walkspeed;
        }
    }
    void ClambSpeed() //clamp the speed of player 
    {
        rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxspeed);
    }
    void Jump() //extend araycast from the player to the ground to check if the player touch the ground or not, then make aforce from the ground
    {
        isground = Physics.Raycast(transform.position, Vector3.down, 1.1f); // return true or false
        if(Input.GetKeyDown(KeyCode.Space) && isground)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }
    void Mov() //the movement of player
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(h, 0f, v);
        
        rb.AddForce(move * currspeed);
    }

// --- MAIN FUNC
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currspeed = walkspeed;
    }

    void FixedUpdate()
    {
        Sprint();
        ClambSpeed();
        Jump();
        Mov();
    }

// ---
}