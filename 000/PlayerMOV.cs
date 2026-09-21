using UnityEngine;

public class PlayerMOV : MonoBehaviour
{
    public float playerSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical"); // Input key W, S ; -> (+1 or 0 or -1)
        float h = Input.GetAxis("Horizontal"); // Input key A, D ; -> (+1 or 0 or -1)

        Vector3 move = new Vector3(h, 0f, v);
        rb.AddForce(move * playerSpeed);

    }    
}
