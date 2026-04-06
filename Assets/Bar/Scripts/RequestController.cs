using UnityEngine;

public class RequestController : MonoBehaviour
{
    bool hasOrdered = false;
    bool waitingForDrink = false;
    [SerializeField] float radius;

    [SerializeField] LayerMask glassMask;

    [SerializeField] string textRequest;
    [SerializeField] float timeLapse;

    SetDrinkType glass;

    void AskForDrink()
    {
        if(!hasOrdered)
        {
            Debug.Log(textRequest);
            waitingForDrink = true;

        }
    }

    private void ActivateOrderArea()
    {
        if (Physics.CheckSphere(transform.position, radius, glassMask))
        {

        }
    }

    void GetGlass()
    {
        Collider[] glasses = Physics.OverlapSphere(transform.position, radius, glassMask);
    }


}
