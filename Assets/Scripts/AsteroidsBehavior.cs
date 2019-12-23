using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 velocity;

    void Start()
    {
        // When Asteroid is created, give it a random translation
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        velocity = new Vector3(x, 0.0f, z);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }

}
