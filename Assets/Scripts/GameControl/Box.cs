using System;
using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField] private Sprite wholeBox;
    [SerializeField] private Sprite destroyedBox;
    [SerializeField] private SpriteRenderer boxSpriteRenderer;
    [SerializeField] private GameObject evilSnail;

    private bool snailMoving;

    private void Start()
    {
        boxSpriteRenderer = GetComponent<SpriteRenderer>();
        boxSpriteRenderer.sprite = wholeBox;
    }

    private void Update()
    {
        if (snailMoving)
        {
            evilSnail.transform.position = Vector2.MoveTowards(evilSnail.transform.position, new Vector3(0, -4.2f, 0f), 0.2f * Time.deltaTime);
        }
    }

    public void DestroyBox()
    {
        snailMoving = true;
        
        boxSpriteRenderer.sprite = destroyedBox;
        GameManager.Instance.isBoxDestroyed = true;
        
        evilSnail.SetActive(true);
        evilSnail.transform.position += new Vector3(0f, 0.5f, 0);
        
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.7f);
    }
}
