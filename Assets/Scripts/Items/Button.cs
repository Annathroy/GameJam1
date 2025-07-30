using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject upperRightChamberLocked;
    public GameObject upperRightChamberUnlocked;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChamberControl();
        MoveButtonInside();
        GetComponent<Collider2D>().isTrigger = false;
    }
    private void ChamberControl()
    {
        upperRightChamberLocked.SetActive(false);
        upperRightChamberUnlocked.SetActive(true);
    }
    private void MoveButtonInside()
    {           
        //add sound
                transform.position = new Vector2(transform.position.x-0.3f, transform.position.y);
    }
}
