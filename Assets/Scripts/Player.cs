using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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
        Move();
    }

    [SerializeField]
    private float moveSpeed;

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dirVector = new Vector3(x, y, 0).normalized;
        Vector3 moveVector = dirVector * moveSpeed * Time.deltaTime;

        transform.position += moveVector;
    }
}
