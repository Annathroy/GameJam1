using System.Collections;
using TMPro;
using UnityEngine;

public class DynamiteCapsule : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private GameObject plantedTnt;

    private bool isInside;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && GameManager.Instance.HasDynamite() && isInside)
        {
            plantedTnt.SetActive(true);
            StartCoroutine(WaitForExplosion());
            // TODO: Change the model
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

    private IEnumerator WaitForExplosion()
    {
        UIManager.Instance.HideDynamiteImage();
        yield return new WaitForSeconds(1.5f);
        AudioManager.Instance.PlantDynamiteSound();
        plantedTnt.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.isTntExploded = true;
        GameManager.Instance.peopleSaved++;
    }
}
