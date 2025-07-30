using UnityEngine;

public class Drill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.PickUpScrewdriver();
            // TODO: Show in UI
    
            Destroy(gameObject);
        }
    }
}
