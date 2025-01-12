using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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

        if (distance < traceDistance)
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

        velocity = runVector;

        Vector3 newVector = transform.position + moveVector;
        transform.position = newVector;
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
        Vector3 newVector = transform.position + moveVector;
        transform.position = newVector;
    }

    IEnumerator UpdateVelocity()
    {
        while (true)
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
