using UnityEngine;

public class PlayerBelowPlatform : MonoBehaviour
{
    
    private void Awake()
    {
     
    }
    

    private void Start()
    {
        GameManager.Instance.isPlayerBelowPlatform = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerBelowPlatform = true;
            
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerBelowPlatform = false;
        }
    }
}
