using NUnit.Framework;
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
    int currentIndex;
    bool justExit = true;
    bool glassOnHand;
    [SerializeField] Transform _glassPos;

    SpawnCustomer counter;

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
        counter = FindAnyObjectByType<SpawnCustomer>();
        AssignDeliver();
    }

    private void Update()
    {
        if (deliverAssigned != null && !posReached)
        {
            MoveTowardsDeliver();

            if (currentIndex == request.positions.Length)
            {
                CheckPositionReached();
            }
        }

        if(request.glassPlaced)
        {
            request.glassPlaced = false;
            DoAnimation();
        }

        if(onExit)
        {
            if (justExit)
            {
                justExit = false;
                currentIndex -= 2;
                request.hasOrdered = false;
            }
            
            MoveTowardsExit();
        }

        if(Physics.CheckSphere(pos.position, mRadius, exitMask) && onExit)
        {
            counter.counter--;
            gameObject.SetActive(false);
        }

        if (glassOnHand)
        {
            request._glassObject.transform.position = _glassPos.position;
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
        if (currentIndex >= request.positions.Length) return;

        if (!movingToTarget && request.positions[currentIndex] != null)
        {
            movingToTarget = true;
            target = new Vector3(request.positions[currentIndex].position.x, transform.position.y, request.positions[currentIndex].position.z);
        }

        if (movingToTarget)
        {
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;

            float threshold = 0.1f;
            if (Vector3.Distance(transform.position, target) < threshold)
            {
                movingToTarget = false;
                currentIndex++; // pasar al siguiente punto
            }
        }

        //target = new Vector3(deliverAssigned.transform.position.x, transform.position.y, deliverAssigned.transform.position.z);
        //transform.LookAt(target);
        //transform.position += transform.forward * speed *  Time.deltaTime;
    }

    void DoAnimation()
    {
        StartCoroutine(AnimationTime());
    }

    void MoveTowardsExit()
    {
        request.isTaken = false;
        if (currentIndex >= request.positions.Length) return;


        if (!movingToTarget && request.positions[currentIndex] != null)
        {
            movingToTarget = true;
            target = new Vector3(request.positions[currentIndex].position.x, transform.position.y, request.positions[currentIndex].position.z);
        }

        if (movingToTarget)
        {
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;

            float threshold = 0.1f;
            if (Vector3.Distance(transform.position, target) < threshold)
            {
                movingToTarget = false;
                currentIndex--; // pasar al siguiente punto
            }
        }
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
            glassOnHand = true;
            animator.SetBool("pickGlass", false);
            yield return new WaitForSeconds(3f);
            glassOnHand = false;
            request._glassObject.SetActive(false);
            animator.SetBool("isWaiting", false);
        }
        else
        {
            animator.SetBool("pickGlass", true);
            glassOnHand = true;
            yield return new WaitForSeconds(3f);
            animator.SetBool("pickGlass", false);
            glassOnHand = false;
            request._glassObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            animator.SetBool("isWaiting", false);
            animator.SetBool("isSitting", false);
        }
        onExit = true;
    }
}
