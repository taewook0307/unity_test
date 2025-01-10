using UnityEngine;

public class MapData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal Vector3 GetMapSize()
    {
        return mapRenderer.bounds.size;
    }

    internal float GetHalfMapSizeX()
    {
        return mapRenderer.bounds.size.x / 2f;
    }

    internal float GetHalfMapSizeY()
    {
        return mapRenderer.bounds.size.y / 2f;
    }

    internal bool IsMapNear(Vector3 _checkVector)
    {
        float halfX = GetHalfMapSizeX();
        float halfY = GetHalfMapSizeY();

        if (Mathf.Abs(_checkVector.x - halfX) < 0.1f
            || Mathf.Abs(_checkVector.y - halfY) < 0.1f)
        {
            return true;
        }

        return false;
    }

    internal Vector3 BlockMapOut(Vector3 _checkVector)
    {
        Vector3 returnVector = _checkVector;

        float halfX = GetHalfMapSizeX();
        float halfY = GetHalfMapSizeY();

        if (returnVector.x < -halfX)
        {
            returnVector.x = -halfX;
        }

        if(returnVector.y < -halfY)
        {
            returnVector.y = -halfY;
        }

        if(returnVector.x > halfX)
        {
            returnVector.x = halfX;
        }

        if (returnVector.y > halfY)
        {
            returnVector.y = halfY;
        }

        return returnVector;
    }

    private Renderer mapRenderer;
}
