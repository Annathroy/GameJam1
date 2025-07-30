using UnityEngine;

public class Button : MonoBehaviour
{
    public static Button Instance;
    public GameObject upperRightChamberLocked;
    public GameObject upperRightChamberUnlocked;
    public bool isButtonPressed = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChamberControl();
        MoveButtonInside();
        GetComponent<Collider2D>().isTrigger = false;
        isButtonPressed = true;
    }
    private void ChamberControl()
    {
        upperRightChamberLocked.SetActive(false);
        upperRightChamberUnlocked.SetActive(true);
    }
    private void MoveButtonInside()
    {
        //add sound
        transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y);
    }
}
