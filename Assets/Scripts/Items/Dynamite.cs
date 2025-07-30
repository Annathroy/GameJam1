using System;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            GameManager.Instance.PickUpDynamite();
            
            gameObject.SetActive(false);
        }
    }
}
