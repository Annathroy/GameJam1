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
    private bool isScrewing;

    private Coroutine wiggleCoroutine;

    [SerializeField] private SpriteRenderer capsuleRenderer;

    [SerializeField] private Sprite closedCapsule;
    [SerializeField] private Sprite openCapsule;
        
    
    private void Start()
    {
        capsuleRenderer.sprite = closedCapsule;
        startPosition = transform.position;
        targetPosition = startPosition + Vector2.left * 0.5f;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInside)
        {
            if (!GameManager.Instance.HasScrewdriver())
            {
                if (wiggleCoroutine != null) StopCoroutine(wiggleCoroutine);
                wiggleCoroutine = StartCoroutine(WiggleTheScrew());
            }
            else
            {
                isMoving = true;
                if (!isScrewing)
                {
                    AudioManager.Instance.PlayScrewdriverSound();
                    GameManager.Instance.PlayerMovementDisabled = true;
                    isScrewing = true;
                }
            }
        }
        
        if (isWiggling)
        {
            float hover = startPosition.y + (Mathf.PingPong(Time.time * 0.3f, 0.1f) - 0.05f);
            transform.position = new Vector2(transform.position.x, hover);
        }

        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / 3.9f);

            transform.position = Vector2.Lerp(startPosition, targetPosition, t);

            if (t >= 1f)
            {
                GameManager.Instance.isNpcUnscrewed = true;
                GameManager.Instance.peopleSaved++;
                isMoving = false;
                // TODO: Change capsule model
                capsuleRenderer.sprite = openCapsule;
                
                GameManager.Instance.PlayerMovementDisabled = false;
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
        AudioManager.Instance.PlayVibrateScrew();
        yield return new WaitForSeconds(1.5f);
        isWiggling = false;
    }
}
