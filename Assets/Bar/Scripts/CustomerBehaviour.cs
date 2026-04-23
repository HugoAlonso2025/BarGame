using NUnit.Framework;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    [SerializeField] Transform pos;
    [SerializeField] Transform _glassPos;

    Vector3 target;

    GameObject deliverAssigned;
    [SerializeField] GameObject _canvas;

    [SerializeField] LayerMask askPos;
    [SerializeField] LayerMask exitMask;

    [SerializeField] float speed;
    [SerializeField] float radius;
    [SerializeField] float mRadius;

    int currentIndex;

    bool posReached = false;
    bool onExit = false;
    bool movingToTarget;
    bool justExit = true;
    bool glassOnHand;

    RequestController request;
    SpawnCustomer counter;
    ExpressionManager expression;
    UIBehaviour ui;
    [SerializeField] RequestController[] requests;
    RespawnGlass spawnGlass;

    Animator animator;

    private void Start()
    {
        requests = FindObjectsOfType<RequestController>();
        animator = GetComponent<Animator>();
        counter = FindAnyObjectByType<SpawnCustomer>();
        expression = GetComponentInChildren<ExpressionManager>();
        ui = GetComponentInChildren<UIBehaviour>();
        AssignDeliver();
        expression.SetBaseActive();
    }

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
                _canvas.SetActive(false);
                justExit = false;
                currentIndex -= 2;
                request.hasOrdered = false;
            }
            
            MoveTowardsExit();
        }

        if(Physics.CheckSphere(pos.position, mRadius, exitMask) && onExit)
        {
            request.fail = false;
            request.sucess = false;
            counter.counter--;
            gameObject.SetActive(false);
        }

        if (glassOnHand)
        {
            request._glassObject.transform.position = _glassPos.position;
        }
    }

    void ActivateUI()
    {
        switch(request.option)
        {
            case 0:

                ui.SetActiveBlue();
                break;

            case 1:

                ui.SetActiveBlueHielo();
                break;

            case 2:

                ui.SetActiveBlueLima();
                break;

            case 3:

                ui.SetActiveBlueHieloLima();
                break;

            case 4:

                ui.SetActiveRed();
                break;

            case 5:

                ui.SetActiveRedHielo();
                break;

            case 6:

                ui.SetActiveRedLima();
                break;

            case 7:

                ui.SetActiveRedHieloLima();
                break;

            case 8:

                ui.SetActiveYellow();
                break;

            case 9:

                ui.SetActiveYellowHielo();
                break;

            case 10:

                ui.SetActiveYellowLima();
                break;

            case 11:

                ui.SetActiveYellowHieloLima();
                break;

            case 12:

                ui.SetActiveOrange();
                break;

            case 13:

                ui.SetActiveOrangeHielo();
                break;

            case 14:

                ui.SetActiveOrangeLima();
                break;

            case 15:

                ui.SetActiveOrangeHieloLima();
                break;

            case 16:

                ui.SetActiveGreen();
                break;

            case 17:

                ui.SetActiveGreenHielo();
                break;

            case 18:

                ui.SetActiveGreenLima();
                break;

            case 19:

                ui.SetActiveGreenHieloLima();
                break;

            case 20:

                ui.SetActivePurple();
                break;

            case 21:

                ui.SetActivePurpleHielo();
                break;

            case 22:

                ui.SetActivePurpleLima();
                break;

            case 23:

                ui.SetActivePurpleHieloLima();
                break;

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
            else
            {
                StartCoroutine(Talk());
                ActivateUI();
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
                currentIndex++;
            }
        }
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
                currentIndex--;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(pos.position, radius);
        Gizmos.DrawWireSphere(pos.position, mRadius);
    }

    IEnumerator Talk()
    {
        expression.SetTalkActive();
        yield return new WaitForSeconds(3);
        expression.SetBaseActive();
    }

    IEnumerator Sit()
    {
        animator.SetBool("isSitting", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("isWaiting", true);
        ActivateUI();
        StartCoroutine(Talk());
        
    }

    IEnumerator AnimationTime()
    {
        if (!request.isTable)
        {
            animator.SetBool("pickGlass", true);
            yield return new WaitForSeconds(0.7f);
            glassOnHand = true;
            animator.SetBool("pickGlass", false);
            if (request.fail)
            {
                expression.SetAngryActive();
            }
            else if (request.sucess)
            {
                expression.SetHappyActive();
            }
            yield return new WaitForSeconds(3f);
            glassOnHand = false;
            spawnGlass = request._glassObject.GetComponent<RespawnGlass>();
            spawnGlass.InstantiateGlass();
            Destroy(request._glassObject);
            animator.SetBool("isWaiting", false);
        }
        else
        {
            animator.SetBool("pickGlass", true);
            glassOnHand = true;
            yield return new WaitForSeconds(3f);
            animator.SetBool("pickGlass", false);
            glassOnHand = false;
            if (request.fail)
            {
                expression.SetAngryActive();
            }
            else if (request.sucess)
            {
                expression.SetHappyActive();
            }
            spawnGlass = request._glassObject.GetComponent<RespawnGlass>();
            spawnGlass.InstantiateGlass();
            Destroy(request._glassObject);
            yield return new WaitForSeconds(1f);
            animator.SetBool("isWaiting", false);
            animator.SetBool("isSitting", false);
        }
        onExit = true;
    }
}
