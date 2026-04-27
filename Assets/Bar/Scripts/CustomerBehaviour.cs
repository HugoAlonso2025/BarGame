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
    [SerializeField] LayerMask doorMask;

    [SerializeField] float speed;
    [SerializeField] float radius;
    [SerializeField] float mRadius;

    public int currentIndex;

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
    DoorAnimation door;

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
        door = FindAnyObjectByType<DoorAnimation>();
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

    void OpenDoor()
    {
        if (!onExit && Physics.CheckSphere(pos.position, mRadius, doorMask))
        {
            door.OpenDoorEnter();
        }
        else if (onExit && Physics.CheckSphere(pos.position, mRadius, doorMask))
        {
            door.OpenDoorExit();
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
                currentIndex--;
                request.hasOrdered = false;
            }
            
            MoveTowardsExit();
        }

        if(Physics.CheckSphere(pos.position, mRadius, exitMask) && onExit)
        {
            request.fail = false;
            request.sucess = false;
            counter.counter--;
            Destroy(gameObject);
        }

        if (glassOnHand)
        {
            request._glassObject.transform.position = _glassPos.position;
        }

        OpenDoor();
    }

    void ActivateUI()
    {
        switch (request.option)
        {
            // VASO (V)
            case 0: ui.SetActiveBlueV(); break;
            case 1: ui.SetActiveBlueHieloV(); break;
            case 2: ui.SetActiveBlueLimaV(); break;
            case 3: ui.SetActiveBlueHieloLimaV(); break;

            case 4: ui.SetActiveRedV(); break;
            case 5: ui.SetActiveRedHieloV(); break;
            case 6: ui.SetActiveRedLimaV(); break;
            case 7: ui.SetActiveRedHieloLimaV(); break;

            case 8: ui.SetActiveYellowV(); break;
            case 9: ui.SetActiveYellowHieloV(); break;
            case 10: ui.SetActiveYellowLimaV(); break;
            case 11: ui.SetActiveYellowHieloLimaV(); break;

            case 12: ui.SetActiveOrangeV(); break;
            case 13: ui.SetActiveOrangeHieloV(); break;
            case 14: ui.SetActiveOrangeLimaV(); break;
            case 15: ui.SetActiveOrangeHieloLimaV(); break;

            case 16: ui.SetActiveGreenV(); break;
            case 17: ui.SetActiveGreenHieloV(); break;
            case 18: ui.SetActiveGreenLimaV(); break;
            case 19: ui.SetActiveGreenHieloLimaV(); break;

            case 20: ui.SetActivePurpleV(); break;
            case 21: ui.SetActivePurpleHieloV(); break;
            case 22: ui.SetActivePurpleLimaV(); break;
            case 23: ui.SetActivePurpleHieloLimaV(); break;

            // COPA (C)
            case 24: ui.SetActiveBlueC(); break;
            case 25: ui.SetActiveBlueHieloC(); break;
            case 26: ui.SetActiveBlueLimaC(); break;
            case 27: ui.SetActiveBlueHieloLimaC(); break;

            case 28: ui.SetActiveRedC(); break;
            case 29: ui.SetActiveRedHieloC(); break;
            case 30: ui.SetActiveRedLimaC(); break;
            case 31: ui.SetActiveRedHieloLimaC(); break;

            case 32: ui.SetActiveYellowC(); break;
            case 33: ui.SetActiveYellowHieloC(); break;
            case 34: ui.SetActiveYellowLimaC(); break;
            case 35: ui.SetActiveYellowHieloLimaC(); break;

            case 36: ui.SetActiveOrangeC(); break;
            case 37: ui.SetActiveOrangeHieloC(); break;
            case 38: ui.SetActiveOrangeLimaC(); break;
            case 39: ui.SetActiveOrangeHieloLimaC(); break;

            case 40: ui.SetActiveGreenC(); break;
            case 41: ui.SetActiveGreenHieloC(); break;
            case 42: ui.SetActiveGreenLimaC(); break;
            case 43: ui.SetActiveGreenHieloLimaC(); break;

            case 44: ui.SetActivePurpleC(); break;
            case 45: ui.SetActivePurpleHieloC(); break;
            case 46: ui.SetActivePurpleLimaC(); break;
            case 47: ui.SetActivePurpleHieloLimaC(); break;
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
