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
    bool movingToTarget;



    Animator animator;

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
        animator = GetComponent<Animator>();
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
            animator.SetBool("isWaiting", true);

            if (request.isTable)
            {
                StartCoroutine(Sit());
            }
        }
    }

    void MoveTowardsDeliver()
    {
        //for(int i = 0;  i < request.positions.Length; i++)
        //{
        //    if (request.positions[i] != null && !movingToTarget)
        //    {
        //        movingToTarget = true;
        //        target = new Vector3(request.positions[i].position.x, transform.position.y, request.positions[i].position.z);
        //        continue;
        //    }
        //}

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
        request.isTaken = false;
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

    IEnumerator Sit()
    {
        animator.SetBool("isSitting", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isWaiting", true);
    }

    IEnumerator AnimationTime()
    {
        if (!request.isTable)
        {
            animator.SetBool("pickGlass", true);
            yield return new WaitForSeconds(0.7f);
            animator.SetBool("pickGlass", false);
            yield return new WaitForSeconds(3f);
            animator.SetBool("isWaiting", false);
        }
        else
        {
            animator.SetBool("pickGlass", true);
            yield return new WaitForSeconds(3f);
            animator.SetBool("pickGlass", false);
            animator.SetBool("isWaiting", false);
            animator.SetBool("isSitting", false);
        }
        onExit = true;
    }
}
