using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    
    private NPCHopping npcHoppingScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        npcHoppingScript = GetComponent<NPCHopping>();
        npcHoppingScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.peopleSaved >= 4)
        {
            transform.position = new Vector2(transform.position.x, -4.3f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(2f, -4.3f, 0f), 2f * Time.deltaTime);
            npcHoppingScript.enabled = true;
        }

        if (Vector2.Distance(transform.position, new Vector3(2f, -4.3f, 0f)) < 0.3f)
        {
            npcHoppingScript.enabled = false;
        }
    }
}
