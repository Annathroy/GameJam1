using TMPro;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static Button Instance;
    public GameObject upperRightChamberLocked;
    public GameObject upperRightChamberUnlocked;
    public bool isInside;
    public bool isButtonPressed;
    public TMP_Text interactionText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside && !isButtonPressed)
        {
            ChamberControl();
            MoveButtonInside();
            isButtonPressed = true;
            //GetComponent<Collider2D>().isTrigger = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInside = true;
        if (!isButtonPressed) interactionText.text = $"Press E to push the button";
        else interactionText.text = $"";
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInside = false;
        interactionText.text = $"";
    }

    private void ChamberControl()
    {
        upperRightChamberLocked.SetActive(false);
        upperRightChamberUnlocked.SetActive(true);
        GameManager.Instance.peopleSaved++;
    }
    
    private void MoveButtonInside()
    {
        //add sound
        transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
    }
}
