using System;
using UnityEngine;

public class PlatformUpAndDown : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float hover = startPosition.y - 1f + Mathf.Sin(Time.time * 1f) * 1.5f;
        transform.position = new Vector2(transform.position.x, hover);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player) && GameManager.Instance.isPlayerBelowPlatform == true)
        {
            UIManager.Instance.ShowGameOverCrushedEndingMenu();
            Time.timeScale = 0f; // Stop the game
        }
    }

}
