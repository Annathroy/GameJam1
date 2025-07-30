using System.Collections;
using TMPro;
using UnityEngine;

public class DynamiteCapsule : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;

    private bool isInside;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.HasDynamite() && isInside)
        {
            // TODO: Change the model & free the player
            Debug.Log("The C4 was planted");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (GameManager.Instance.HasDynamite())
            {
                interactionText.text = $"Press E to plant the C4";
                isInside = true;
            }
            else
            {
                interactionText.text = $"You don't have the required item";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactionText.text = $"";
        isInside = false;
    }
    
}
