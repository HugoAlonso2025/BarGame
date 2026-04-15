using System.Collections;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    [SerializeField] RequestController[] requests;
    GameObject deliverAssigned;
    Vector3 target;
    [SerializeField] float speed;
    [SerializeField] float radius;
    [SerializeField] float mRadius;
    [SerializeField] Transform pos;
    GameObject exitPos;
    bool posReached = false;
    [SerializeField] LayerMask askPos;
    [SerializeField] LayerMask exitMask;
    RequestController request;
    bool onExit = false;

    void AssignDeliver()
    {
        for (int i = 0; i < requests.Length; i++)
        {
            if (!requests[i].isTaken)
            {
                request = requests[i];
                deliverAssigned = request.gameObject;
                request = deliverAssigned.GetComponent<RequestController>();
                continue;
            }
        }
    }

    private void Start()
    {
        requests = FindObjectsOfType<RequestController>();
        exitPos = GameObject.Find("SpawnPos");
        AssignDeliver();
    }

    private void Update()
    {
        if (deliverAssigned != null && !posReached)
        {
            CheckPositionReached();
            MoveTowardsDeliver();
        }

        if(request.glassPlaced)
        {
            request.glassPlaced = false;
            DoAnimation();
        }

        if(onExit)
        {
            MoveTowardsExit();
        }

        if(Physics.CheckSphere(pos.position, mRadius, exitMask) && onExit)
        {
            gameObject.SetActive(false);
        }
    }

    void CheckPositionReached()
    {
        if(Physics.CheckSphere(pos.position, radius,  askPos))
        {
            posReached = true;
            request.isTaken = true;
            request.AskForDrink();
        }
    }

    void MoveTowardsDeliver()
    {
        target = new Vector3(deliverAssigned.transform.position.x, transform.position.y, deliverAssigned.transform.position.z);
        transform.LookAt(target);
        transform.position += transform.forward * speed *  Time.deltaTime;
    }

    void DoAnimation()
    {
        StartCoroutine(AnimationTime());
    }

    void MoveTowardsExit()
    {
        target = new Vector3(exitPos.transform.position.x, transform.position.y, exitPos.transform.position.z);
        transform.LookAt(exitPos.transform);
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pos.position, radius);
        Gizmos.DrawWireSphere(pos.position, mRadius);
    }

    IEnumerator AnimationTime()
    {
        yield return new WaitForSeconds(2);
        onExit = true;
    }
}
