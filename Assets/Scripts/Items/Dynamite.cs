using UnityEngine;

public class Dynamite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.PickUpDynamite();
            
            Destroy(gameObject);
        }
    }
}
