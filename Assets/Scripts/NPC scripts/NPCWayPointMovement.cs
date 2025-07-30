using UnityEngine;

public class NPCWayPointMovement : MonoBehaviour
{
    public static NPCWayPointMovement Instance;
    [SerializeField] private GameObject wayPoint1;
    [SerializeField] private GameObject wayPoint2;
    [SerializeField] private GameObject wayPoint3;
    [SerializeField] private GameObject wayPoint4;
    [SerializeField] private GameObject wayPoint5;
    [SerializeField] private bool reachedWayPoint1 = false;
    [SerializeField] private bool reachedWayPoint2 = false;
    [SerializeField] private bool reachedWayPoint3 = false;
    [SerializeField] private bool reachedWayPoint4 = false;
    [SerializeField] private bool reachedWayPoint5 = false;
    private void Update()
    {
        if (reachedWayPoint1 == false && Button.Instance.isButtonPressed==true)
        {
            MoveToWayPoint(wayPoint1);
        }
        if (reachedWayPoint1 && !reachedWayPoint2)
        {
            MoveToWayPoint(wayPoint2);
        }
        else if (reachedWayPoint2 && !reachedWayPoint3)
        {
            MoveToWayPoint(wayPoint3);
        }
        else if (reachedWayPoint3 && !reachedWayPoint4)
        {
            MoveToWayPoint(wayPoint4);
        }
        else if (reachedWayPoint4 && !reachedWayPoint5)
        {
            MoveToWayPoint(wayPoint5);
        }
        else if (reachedWayPoint5)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }
    private void MoveToWayPoint(GameObject wayPoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint.transform.position, 2f * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint.transform.position) < 0.1f)
        {
            if (wayPoint == wayPoint1) reachedWayPoint1 = true;
            else if (wayPoint == wayPoint2) reachedWayPoint2 = true;
            else if (wayPoint == wayPoint3) reachedWayPoint3 = true;
            else if (wayPoint == wayPoint4) reachedWayPoint4 = true;
            else if (wayPoint == wayPoint5) reachedWayPoint5 = true;
           
        }
    }
}
