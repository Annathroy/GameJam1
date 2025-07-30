using TMPro;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerTouchingExitDoor = true;
            interactionText.text = $"Press E to leave";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    { 
        GameManager.Instance.isPlayerTouchingExitDoor = false;
        interactionText.text = $"";
        
    }
}
