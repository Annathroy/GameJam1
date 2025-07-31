using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    private bool isInside;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            GameManager.Instance.PickUpScrewdriver();
            Destroy(gameObject);
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            isInside = false;
        }
    }
}
