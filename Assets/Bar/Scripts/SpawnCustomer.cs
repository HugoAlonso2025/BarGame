using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] RequestController[] requests;
    GameObject deliverAssigned;
    Transform target;
    [SerializeField] float speed;

    void AsignDeliver()
    {
        if (requests != null)
        {
            for (int i = 0; i < requests.Length; i++)
            {
                if (requests[i] == null)
                {
                    deliverAssigned = requests[i].gameObject;
                    continue;
                }
            }
        }
    }

    private void Start()
    {
        AsignDeliver();
    }

    void MoveTowardsDeliver()
    {
        target = deliverAssigned.transform;
        transform.LookAt(target);
        transform.position = transform.forward *speed *  Time.deltaTime;
    }

    void AskForDrink()
    {
        Debug.Log("Y want a drink");
    }
}
