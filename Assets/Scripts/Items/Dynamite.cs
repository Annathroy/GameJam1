using System;
using TMPro;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;

    private bool isInside;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside && GameManager.Instance.HasScrewdriver())
        {
            GameManager.Instance.PickUpDynamite();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            isInside = true;
            if (GameManager.Instance.HasScrewdriver()) interactionText.text = $"Press E to unscrew the C4";
            else interactionText.text = $"You need the screwdriver for this";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInside = false;
        interactionText.text = $"";
    }
}
