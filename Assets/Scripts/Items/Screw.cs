using System;
using System.Collections;
using UnityEngine;

public class Screw : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isWiggling;
    
    private void Update()
    {
        if (isWiggling)
        {
            float hover = startPosition.y - 2.5f + (Mathf.PingPong(Time.time * 10f, 0.05f) - 0.025f);
            transform.position = new Vector2(transform.position.x, hover);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            StartCoroutine(WiggleTheScrew());
        }
    }

    private IEnumerator WiggleTheScrew()
    {
        isWiggling = true;
        yield return new WaitForSeconds(1.5f);
        isWiggling = false;
    }
}
