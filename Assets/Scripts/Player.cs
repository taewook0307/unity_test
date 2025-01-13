using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        collectionCount = 5;
        collections.Capacity = collectionCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (true == collision.gameObject.CompareTag("Enemy"))
        {
            CollectMonster(collision.gameObject);
        }
    }

    #region Move
    [SerializeField]
    private float moveSpeed;

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dirVector = new Vector3(x, y, 0).normalized;
        Vector3 moveVector = dirVector * moveSpeed * Time.fixedDeltaTime;

        Vector3 newVector = transform.position + moveVector;

        transform.position = newVector;
    }
    #endregion

    #region Collection
    private List<GameObject> collections = new List<GameObject>();

    private float blankHeight = 0.5f;
    private int collectionCount = 5;

    private void CollectMonster(GameObject monster)
    {
        if(collectionCount <= collections.Count)
        {
            return;
        }

        SpriteRenderer monsterRenderer = monster.GetComponent<SpriteRenderer>();

        if (null != monsterRenderer)
        {
            GameObject rendererObject = new GameObject("CollectionRenderer");
            SpriteRenderer newRenderer = rendererObject.AddComponent<SpriteRenderer>();
            newRenderer.sprite = monsterRenderer.sprite;
            newRenderer.material = monsterRenderer.material;
            newRenderer.enabled = true;

            collections.Add(rendererObject);

            UpdateRendererPositions();

            monster.SetActive(false);
        }
    }

    private void UpdateRendererPositions()
    {
        BoxCollider2D playerCollider = GetComponent<BoxCollider2D>();

        Vector3 basePosition = transform.position + Vector3.up * (playerCollider.bounds.size.y / 2);

        if(collections.Count == 1)
        {
            Vector3 newPosition = basePosition + Vector3.up * blankHeight;
            collections[0].transform.position = newPosition;
            collections[0].transform.SetParent(transform);
        }
        else
        {
            Vector3 newPosition = collections[collections.Count - 2].transform.position + Vector3.up * blankHeight;
            collections[collections.Count - 1].transform.position = newPosition;
            collections[collections.Count - 1].transform.SetParent(transform);
        }
    }

    #endregion
}
