using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]private float thrust = 10.0f;
    [SerializeField] private float rotateSpeed = 90.0f;
    private Rigidbody playerRb;

    public GameObject missile;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, new Vector3(0, 0, 0), transform.rotation);
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
