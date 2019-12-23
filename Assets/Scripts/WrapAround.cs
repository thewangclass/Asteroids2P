using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{

    private float bounds = 25;


    // Update is called once per frame
    void Update()
    {
        ConstraintPosition();
    }

    void ConstraintPosition()
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
