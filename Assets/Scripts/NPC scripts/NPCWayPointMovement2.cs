using UnityEngine;

public class NPCWayPointMovement2 : MonoBehaviour
{
    public static NPCWayPointMovement Instance;
    [SerializeField] private GameObject wayPoint1;
    [SerializeField] private GameObject wayPoint2;
    [SerializeField] private GameObject wayPoint4;
    [SerializeField] private GameObject wayPoint5;
    [SerializeField] private GameObject wayPoint6;
    [SerializeField] private bool reachedWayPoint1 = false;
    [SerializeField] private bool reachedWayPoint2 = false;
    [SerializeField] private bool isOnSpot1 = false;
    [SerializeField] private bool isOnSpot2 = false;
    [SerializeField] private bool isOnSpot3 = false;
    private NPCHopping npcHoppingScript;


    private void Start()
    {
        npcHoppingScript = GetComponent<NPCHopping>();
        npcHoppingScript.enabled = false;
    }

    private void Update()
    {
        if (GameManager.Instance.peopleSaved >= 4)
        {
            transform.position = new Vector2(transform.position.x, -4.3f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-2f, -4.3f), 1.5f * Time.deltaTime);
            npcHoppingScript.enabled = true;

        }
        if (Vector2.Distance(transform.position, new Vector2(-2f, -4.3f)) < 0.3f)
        {
            npcHoppingScript.enabled = false;
        }

        if (GameManager.Instance.peopleSaved < 4)
        {
            if (reachedWayPoint1 == false && GameManager.Instance.isTntExploded)
            {
                MoveToWayPoint(wayPoint1);
                npcHoppingScript.enabled = true;
            }
            if (reachedWayPoint1 && !reachedWayPoint2)
            {
                MoveToWayPoint(wayPoint2);
                npcHoppingScript.enabled = false;
            }
            else if (reachedWayPoint2 && GameManager.Instance.spot1Taken == false && isOnSpot2 == false && isOnSpot3 == false)
            {
                MoveToWayPoint(wayPoint4);
                npcHoppingScript.enabled = false;
            }
            else if (reachedWayPoint2 && GameManager.Instance.spot1Taken == true && GameManager.Instance.spot2Taken == false && isOnSpot1 == false && isOnSpot3 == false)
            {
                MoveToWayPoint(wayPoint5);
                npcHoppingScript.enabled = false;
            }
            else if (reachedWayPoint2 && GameManager.Instance.spot1Taken == true && GameManager.Instance.spot2Taken == true && GameManager.Instance.spot3Taken == false && isOnSpot1 == false && isOnSpot2 == false)
            {
                MoveToWayPoint(wayPoint6);
                npcHoppingScript.enabled = false;
            }
            
        }

    }
    private void MoveToWayPoint(GameObject wayPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, 2f * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint.transform.position) < 0.3f)
        {
            if (wayPoint == wayPoint1) reachedWayPoint1 = true;
            else if (wayPoint == wayPoint2)
            {
                reachedWayPoint2 = true;
                GameManager.Instance.NpcAtLocation++;
                Destroy(gameObject.GetComponent<Rigidbody2D>());
            }
            if (wayPoint == wayPoint4)
            {
                GameManager.Instance.spot1Taken = true;
                isOnSpot1 = true;
            }
            if (wayPoint == wayPoint5)
            {
                GameManager.Instance.spot2Taken = true;
                isOnSpot2 = true;
            }
            if (wayPoint == wayPoint6)
            {
                GameManager.Instance.spot3Taken = true;
                isOnSpot3 = true;
            }


        }
    }
}
