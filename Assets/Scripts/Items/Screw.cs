using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Screw : MonoBehaviour
{
    [SerializeField] private TMP_Text interactionText;
    
    private Vector2 startPosition, targetPosition;
    private bool isWiggling;
    private bool isMoving;

    private float elapsedTime;
    private bool isInside;
    
    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector2.right * 0.5f;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            if (!GameManager.Instance.HasScrewdriver()) StartCoroutine(WiggleTheScrew());
            else isMoving = true;
        }
        
        if (isWiggling)
        {
            float hover = startPosition.y + (Mathf.PingPong(Time.time * 10f, 0.05f) - 0.025f);
            transform.position = new Vector2(transform.position.x, hover);
        }

        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 1f);

            transform.position = Vector2.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                GameManager.Instance.isNpcUnscrewed = true;
                isMoving = false;
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
            if (!GameManager.Instance.HasScrewdriver())
            {
                interactionText.text = $"Press E to wiggle the screw";
            }
            else
            {
                interactionText.text = $"Press E to use the Screwdriver";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            interactionText.text = $"";
            isInside = false;
        }
    }

    private IEnumerator WiggleTheScrew()
    {
        isWiggling = true;
        yield return new WaitForSeconds(1.5f);
        isWiggling = false;
    }
}
