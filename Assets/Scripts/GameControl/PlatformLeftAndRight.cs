using UnityEngine;

public class PlatformLeftAndRight : MonoBehaviour
{
    private Vector3 startPosition;

    // Update is called once per frame
    void Update()
    {
        float hover = startPosition.y-2f + Mathf.Sin(Time.time * 1f) * 1.5f;
        transform.position = new Vector2(hover, transform.position.y);
    }
  
}
