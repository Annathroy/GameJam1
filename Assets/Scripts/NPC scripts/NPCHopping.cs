using System;
using UnityEngine;

public class NPCHopping : MonoBehaviour
{
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnEnable()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float hover = startPosition.y + Mathf.PingPong(Time.time * 2f, 0.3f * 2f) - 0.150f;
        transform.position = new Vector2(transform.position.x, hover);
    }
}
