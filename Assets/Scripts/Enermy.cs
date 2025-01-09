using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Random.InitState(System.Guid.NewGuid().GetHashCode());
        StartCoroutine(UpdateVelocity());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 myPosition = transform.position;
        Vector3 targetPositionn = target.transform.position;

        myPosition.z = 0;
        targetPositionn.z = 0;
        float distance = (targetPositionn - myPosition).magnitude;

        if(distance < traceDistance)
        {
            RunAway();
        }
        else
        {
            RandomMove();
        }
    }

    void RunAway()
    {
        Vector3 myPosition = transform.position;
        Vector3 targetPositionn = target.transform.position;

        myPosition.z = 0;
        targetPositionn.z = 0;

        Vector3 runVector = (myPosition - targetPositionn).normalized;
        Vector3 moveVector = runVector * moveSpeed * Time.fixedDeltaTime;

        transform.position += moveVector;
    }

    Vector3 GetRandomVelocity()
    {
        float dirX = Random.Range(-1f, 1f);
        float dirY = Random.Range(-1f, 1f);

        Vector3 returnValue = new Vector3(dirX, dirY, 0).normalized;
        return returnValue;
    }

    void RandomMove()
    {
        Vector3 moveVector = velocity * moveSpeed * Time.fixedDeltaTime;
        transform.position += moveVector;
    }

    IEnumerator UpdateVelocity()
    {
        while(true)
        {
            velocity = GetRandomVelocity();

            yield return new WaitForSeconds(RandomTimer);
        }
    }

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float traceDistance = 1f;

    [SerializeField]
    private float moveSpeed = 2f;

    [SerializeField]
    private float RandomTimer = 1f;

    private Vector3 velocity;
}
