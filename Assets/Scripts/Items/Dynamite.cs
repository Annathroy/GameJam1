using System.Collections;
using TMPro;
using UnityEngine;

public class Dynamite : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;
    [SerializeField] private GameObject screwPrefab;

    private Vector2 startPosition, targetPosition;
    
    private bool isInside;
    private bool isMoving;
    private bool isWiggling;
    
    private float elapsedTime;

    private Coroutine wiggleCoroutine;
    
    private void Start()
    {
        startPosition = screwPrefab.transform.position;
        targetPosition = startPosition + Vector2.left * 0.5f;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            if (GameManager.Instance.HasScrewdriver())
            {
                isMoving = true;
            }
            else
            {
                if (wiggleCoroutine != null) StopCoroutine(wiggleCoroutine);
                wiggleCoroutine = StartCoroutine(WiggleTheScrew());
            }
        }
        
        if (isWiggling)
        {
            float hover = startPosition.y + (Mathf.PingPong(Time.time * 0.3f, 0.1f) - 0.05f);
            screwPrefab.transform.position = new Vector2(screwPrefab.transform.position.x, hover);
        }
        
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 1f);

            screwPrefab.transform.position = Vector2.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                isMoving = false;
                GameManager.Instance.PickUpDynamite();
                // TODO: Change capsule model
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            isInside = true;
            if (GameManager.Instance.HasScrewdriver()) interactionText.text = $"Press E to unscrew the C4";
            else interactionText.text = $"You need the screwdriver for this";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isInside = false;
        interactionText.text = $"";
    }
    
    private IEnumerator WiggleTheScrew()
    {
        isWiggling = true;
        yield return new WaitForSeconds(1.5f);
        isWiggling = false;
    }
}
