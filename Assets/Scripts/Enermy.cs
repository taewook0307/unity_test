using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float distance = (target.transform.position - transform.position).magnitude;

        if(distance < traceDistance)
        {
            RunAway();
        }
    }

    void RunAway()
    {
        Vector3 runVector = (transform.position - target.transform.position).normalized;
        Vector3 moveVector = runVector * moveSpeed * Time.fixedDeltaTime;

        transform.position += moveVector;
    }

    [SerializeField]
    GameObject target;

    [SerializeField]
    float traceDistance = 1f;

    [SerializeField]
    float moveSpeed = 2f;
}