using UnityEngine;

public class Box : MonoBehaviour
{

    [SerializeField] private Sprite wholeBox;
    [SerializeField] private Sprite destroyedBox;
    [SerializeField] private SpriteRenderer boxSpriteRenderer;

    private void Start()
    {
        boxSpriteRenderer = GetComponent<SpriteRenderer>();
        boxSpriteRenderer.sprite = wholeBox;
    }

    public void DestroyBox()
    {
        boxSpriteRenderer.sprite = destroyedBox;
        GameManager.Instance.isBoxDestroyed = true;
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.7f);
    }
}
