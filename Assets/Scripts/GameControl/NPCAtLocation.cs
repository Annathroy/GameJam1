using System;
using UnityEngine;
using TMPro;

public class NPCAtLocation : MonoBehaviour
{
    public bool isPlayerAtLocation = false;
    [SerializeField] private TextMeshProUGUI interactText;

    [SerializeField] private GameObject closedCapsule;
    [SerializeField] private GameObject brokenCapsule;

    //[SerializeField] private GameObject[] npcs;

    private bool isBroken;

    private void Start()
    {
        closedCapsule.SetActive(true);
        brokenCapsule.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.NpcAtLocation == 3 && isPlayerAtLocation)
        {
            if (!isBroken)
            {
                GameManager.Instance.peopleSaved = 4;
                
                closedCapsule.SetActive(false);
                brokenCapsule.SetActive(true);
                
                AudioManager.Instance.PlayGlassBreak();
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                isBroken = true;
            }
            
            //GameManager.Instance.MoveNPCsToEnd(npcs);
            //GameManager.Instance.GameOver();
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
