using UnityEngine;
using TMPro;

public class NPCAtLocation : MonoBehaviour
{
    public bool isPlayerAtLocation = false;
    [SerializeField] private TextMeshProUGUI interactText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.NpcAtLocation == 3 && isPlayerAtLocation)
        {
            GameManager.Instance.peopleSaved++;
            GameManager.Instance.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            isPlayerAtLocation = true;
            interactText.gameObject.SetActive(true);
            if (GameManager.Instance.NpcAtLocation == 3)
            {
                interactText.text = "Press E to save the NPC";
            }
            else
            {
                interactText.text = "This chamber looks unstable";
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            interactText.gameObject.SetActive(false);
            isPlayerAtLocation = false;
        }
    }
}
