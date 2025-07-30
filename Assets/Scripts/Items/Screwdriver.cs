using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.PickUpDrill();
            
            Destroy(gameObject);
        }
    }
}
