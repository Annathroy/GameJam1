using System;
using UnityEngine;

public class NPCWayPointMovement3 : MonoBehaviour
{
    public static NPCWayPointMovement Instance;
    [SerializeField] private GameObject wayPoint1;
    [SerializeField] private GameObject wayPoint2;
    [SerializeField] private GameObject wayPoint3;
    [SerializeField] private GameObject wayPoint4;
    [SerializeField] private GameObject wayPoint5;
    [SerializeField] private GameObject wayPoint6;
    [SerializeField] private GameObject wayPoint7;
    [SerializeField] private GameObject wayPoint8;
    [SerializeField] private bool reachedWayPoint1 = false;
    [SerializeField] private bool reachedWayPoint2 = false;
    [SerializeField] private bool reachedWayPoint3 = false;
    [SerializeField] private bool reachedWayPoint4 = false;
    [SerializeField] private bool reachedWayPoint5 = false;
    [SerializeField] private bool isOnSpot1 = false;
    [SerializeField] private bool isOnSpot2 = false;
    [SerializeField] private bool isOnSpot3 = false;

    private NPCHopping npcHopping;

    private void Start()
    {
        npcHopping = GetComponent<NPCHopping>();
        npcHopping.enabled = false;
    }

    private void Update()
    {
        if (reachedWayPoint1 == false && GameManager.Instance.isNpcUnscrewed)
        {
            MoveToWayPoint(wayPoint1);
            npcHopping.enabled = true;
        }
        if (reachedWayPoint1 && !reachedWayPoint2)
        {
            MoveToWayPoint(wayPoint2);
            npcHopping.enabled = false;
        }
        else if (reachedWayPoint2 && !reachedWayPoint3)
        {
            MoveToWayPoint(wayPoint3);
            npcHopping.enabled = true;
        }

        else if (reachedWayPoint3 && !reachedWayPoint4)
        {
            MoveToWayPoint(wayPoint4);
            npcHopping.enabled = false;
        }
        else if (reachedWayPoint4 && !reachedWayPoint5)
        {
            MoveToWayPoint(wayPoint5);
            npcHopping.enabled = true;
        }
        else if (reachedWayPoint5 && GameManager.Instance.spot1Taken == false && isOnSpot2 == false && isOnSpot3 == false)
        {
            MoveToWayPoint(wayPoint6);
            npcHopping.enabled = false;
        }
        else if (reachedWayPoint5 && GameManager.Instance.spot1Taken == true && GameManager.Instance.spot2Taken == false && isOnSpot1 == false && isOnSpot3 == false)
        {
            MoveToWayPoint(wayPoint7);
            npcHopping.enabled = false;
        }
        else if (reachedWayPoint5 && GameManager.Instance.spot1Taken == true && GameManager.Instance.spot2Taken == true && GameManager.Instance.spot3Taken == false && isOnSpot1 == false && isOnSpot2 == false)
        {
            MoveToWayPoint(wayPoint8);
            npcHopping.enabled = false;
        }


    }
    private void MoveToWayPoint(GameObject wayPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, 2f * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint.transform.position) < 0.3f)
        {
            if (wayPoint == wayPoint1) reachedWayPoint1 = true;
            else if (wayPoint == wayPoint2) reachedWayPoint2 = true;
            else if (wayPoint == wayPoint3) reachedWayPoint3 = true;
            else if (wayPoint == wayPoint4) reachedWayPoint4 = true;
            else if (wayPoint == wayPoint5)
            {
                reachedWayPoint5 = true;
                GameManager.Instance.NpcAtLocation++;
                Destroy(gameObject.GetComponent<Rigidbody2D>());
            }
            if (wayPoint == wayPoint6)
            {
                GameManager.Instance.spot1Taken = true;
                isOnSpot1 = true;

            }
            if (wayPoint == wayPoint7)
            {
                GameManager.Instance.spot2Taken = true;
                isOnSpot2 = true;
            }
            if (wayPoint == wayPoint8)
            {
                GameManager.Instance.spot3Taken = true;
                isOnSpot3 = true;
            }


        }
    }
}
