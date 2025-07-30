using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerTouchingExitDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            
        {
            GameManager.Instance.isPlayerTouchingExitDoor = false;
        }
    }
}
