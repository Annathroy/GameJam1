using UnityEngine;

public class PlayerBelowPlatform : MonoBehaviour
{
    
    private void Awake()
    {
     
    }
    

    private void Start()
    {
        GameManager.Instance.isPlayerBelowPlatform = false;
        GameManager.Instance.isBoxInTriggerZone = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerBelowPlatform = true;
            
        }
        if (collision.gameObject.TryGetComponent(out Box box))
        {
            GameManager.Instance.isBoxInTriggerZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerBelowPlatform = false;
        }
        if (collision.gameObject.TryGetComponent(out Box box))
        {
            GameManager.Instance.isBoxInTriggerZone = false;
        }
    }
}
