using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject missile;
    private float speed = 5.0f;

    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = generateRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if(Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            targetPosition = generateRandomPosition();
        }
    }

    Vector3 generateRandomPosition()
    {
        return new Vector3(Random.Range(-25, 25), 0, Random.Range(-25, 25));
    }
}
