using System;
using System.Collections;
using UnityEngine;

public class Screw : MonoBehaviour
{
    private Vector2 startPosition, targetPosition;
    private bool isWiggling;
    private bool isMoving;

    private float elapsedTime;
    
    private void Start()
    {
        startPosition = transform.position;
        targetPosition = startPosition + Vector2.right * 0.5f;
    }

    private void Update()
    {
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
                isMoving = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            if (!GameManager.Instance.HasScrewdriver()) StartCoroutine(WiggleTheScrew());
            else
            {
                // TODO: Pull out the screw & change the capsule model
                isMoving = true;
            }
        }
    }

    private IEnumerator WiggleTheScrew()
    {
        isWiggling = true;
        yield return new WaitForSeconds(1.5f);
        isWiggling = false;
    }
}
