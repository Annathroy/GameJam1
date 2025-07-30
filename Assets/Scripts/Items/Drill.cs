using UnityEngine;

public class Drill : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.PickUpDrill();
            // TODO: Show in UI
    
            Destroy(gameObject);
        }
    }
}
