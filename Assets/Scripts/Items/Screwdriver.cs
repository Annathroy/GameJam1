using System;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    private bool isInside;

    [SerializeField] private GameObject closedHatch;
    [SerializeField] private GameObject openHatch;

    private void Start()
    {
        closedHatch.SetActive(true);
        openHatch.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            GameManager.Instance.PickUpScrewdriver();
            openHatch.SetActive(true);
            closedHatch.SetActive(false);

            AudioManager.Instance.PlayOpenHatch();
            
            GameManager.Instance.ShowPlayerScrewdriverPopUp();
            UIManager.Instance.ShowScrewdriverImage();
            GetComponent<Collider2D>().enabled = false;
            isInside = false;
            //Destroy(gameObject);
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
