using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject missile;
    private float speed;

    private Vector3 targetPosition;
    private float fieldBoundaries = 25;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = generateRandomPosition();
        speed = generateRandomSpeed();
        player = GameObject.FindWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if(Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            targetPosition = generateRandomPosition();
            speed = generateRandomSpeed();
        }
    }

    Vector3 generateRandomPosition()
    {
        return new Vector3(Random.Range(fieldBoundaries, -fieldBoundaries), 0.0f, Random.Range(fieldBoundaries, -fieldBoundaries));
    }

    float generateRandomSpeed()
    {
        return Random.Range(5, 8);
    }
}
