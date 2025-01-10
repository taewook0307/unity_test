using UnityEngine;

public class MainCam : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 pos = target.transform.position;
        pos.z = -10;
        transform.position = pos;
    }

    [SerializeField]
    private GameObject target;
}
