using UnityEngine;

public class PlatformUpAndDown : MonoBehaviour
{
    [SerializeField] private int scoreWorth = 1;

    private Vector3 startPosition;

    // Update is called once per frame
    void Update()
    {

        float hover = startPosition.y-2f + Mathf.Sin(Time.time * 1f) * 1.5f;
        transform.position = new Vector2(transform.position.x, hover);
    }


}
