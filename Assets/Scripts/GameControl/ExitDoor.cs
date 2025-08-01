using System;
using TMPro;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = closedDoor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerTouchingExitDoor = true;
            spriteRenderer.sprite = openDoor;
            interactionText.text = $"Press E to leave";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.isPlayerTouchingExitDoor = false;
            spriteRenderer.sprite = closedDoor;
            interactionText.text = $"";
        }
    }
}
