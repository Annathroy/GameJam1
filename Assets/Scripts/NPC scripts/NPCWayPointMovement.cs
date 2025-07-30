using UnityEngine;

public class NPCWayPointMovement : MonoBehaviour
{
    public static NPCWayPointMovement Instance;
    [SerializeField] private GameObject wayPoint1;

    [SerializeField] private bool reachedWayPoint1 = false;

    private void Update()
    {
        if (reachedWayPoint1 == false && Button.Instance.isButtonPressed==true)
        {
            MoveToWayPoint(wayPoint1);
        }
       
        else if (reachedWayPoint1)
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
     
           
        }
    }
}
