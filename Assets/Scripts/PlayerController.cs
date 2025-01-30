using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody rb;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update() // Physics-related operations should go here
    {
        // Get input for horizontal and vertical axes
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // calc the movement direction based on the player's forward and right vectors
        Vector3 movement = (transform.right * moveX) + (transform.forward * moveZ);

        // then apply movement to the RigidBody
        rb.AddForce(movement * moveSpeed, ForceMode.Force);
    }

     void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Goal")){
            Debug.Log("You Win");
        } else if(other.CompareTag("DeathPlane")){
            rb.position = startPosition;
        }
    }
}
