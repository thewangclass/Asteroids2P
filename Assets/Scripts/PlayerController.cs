using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]private float thrust = 10.0f;
    [SerializeField] private float rotateSpeed = 90.0f;
    private float bounds = 25;
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstraintPlayerPosition();        

    }

    // Moves player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // need to change this so down is shield and only up is thrust
        playerRb.AddRelativeForce(Vector3.forward * thrust * verticalInput);
        // rotation
        playerRb.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * horizontalInput);
    }

    void ConstraintPlayerPosition()
    {
        // wraparound motion
        if (transform.position.z < -bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, bounds);
            Debug.Log("Bottom Bound");
        }
        else if (transform.position.z > bounds)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -bounds);
            Debug.Log("Top Bound");
        }
        else if (transform.position.x < -bounds)
        {
            transform.position = new Vector3(bounds, transform.position.y, transform.position.z);
            Debug.Log("Left Bound");
        }
        else if (transform.position.x > bounds)
        {
            transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
            Debug.Log("Right Bound");
        }
    }
}
