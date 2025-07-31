using UnityEngine;

public class NPCWayPointMovement : MonoBehaviour
{
    public static NPCWayPointMovement Instance;
    [SerializeField] private GameObject wayPoint1;
    [SerializeField] private GameObject wayPoint2;
    [SerializeField] private GameObject wayPoint3;
    [SerializeField] private GameObject wayPoint4;
    [SerializeField] private bool isOnSpot1 = false;
    [SerializeField] private bool isOnSpot2 = false;
    [SerializeField] private bool isOnSpot3 = false;


    [SerializeField] private bool reachedWayPoint1 = false;

    private void Update()
    {
        if (reachedWayPoint1 == false && Button.Instance.isButtonPressed==true)
        {
            MoveToWayPoint(wayPoint1);
        }
        if (reachedWayPoint1 && GameManager.Instance.spot1Taken==false && isOnSpot2==false && isOnSpot3==false)
        {
            MoveToWayPoint(wayPoint2);
            
        }
        else if (reachedWayPoint1 && GameManager.Instance.spot1Taken == true && GameManager.Instance.spot2Taken == false && isOnSpot1==false && isOnSpot3==false)
        {
            MoveToWayPoint(wayPoint3);
             
        }
        else if (reachedWayPoint1 && GameManager.Instance.spot1Taken == true && GameManager.Instance.spot2Taken == true && GameManager.Instance.spot3Taken == false && isOnSpot1 == false && isOnSpot2 == false)
        {
           
            MoveToWayPoint(wayPoint4);
        }


    }
    private void MoveToWayPoint(GameObject wayPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, 2f * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint.transform.position) < 0.1f)
        {
            if (wayPoint == wayPoint1)
            {
                reachedWayPoint1 = true;
                GameManager.Instance.NpcAtLocation++;
                Destroy(gameObject.GetComponent<Rigidbody2D>());
            }
            if (wayPoint== wayPoint2)
            {
                GameManager.Instance.spot1Taken = true;
                isOnSpot1 = true;
            }
            if (wayPoint == wayPoint3)
            {
                GameManager.Instance.spot2Taken = true;
                isOnSpot2 = true;
            }
            if (wayPoint == wayPoint4)
            {
                GameManager.Instance.spot3Taken = true;
                isOnSpot3 = true;
            }


        }
    }
}
