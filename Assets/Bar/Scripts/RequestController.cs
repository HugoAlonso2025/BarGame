using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RequestController : MonoBehaviour
{

    [SerializeField]  int option;
    [SerializeField]  int drinkMade;

    bool hasOrdered = false;
    bool glassPlaced = false;

    [SerializeField] float radius;

    [SerializeField] Transform glassPos;

    [SerializeField] LayerMask glassMask;

    [SerializeField] string textRequest;
    [SerializeField] float timeLapse;

    Collider[] glasses;

    Transform _glassObject;

    SetDrinkType drink;

    void AskForDrink()
    {
        option = Random.Range(0, 3);
        if(!hasOrdered)
        {
            switch(option)
            {
                case 0:

                    hasOrdered = true;
                    Debug.Log("Quiero un número: " + option);
                    break;

                case 1:

                    hasOrdered = true;
                    Debug.Log("Quiero un número: " + option);
                    break;

                case 2:

                    hasOrdered = true;
                    Debug.Log("Quiero un número: " + option);
                    break;

                case 3:

                    hasOrdered = true;
                    Debug.Log("Quiero un número: " + option);
                    break;
            }  
        }
    }

    void CheckOrder()
    {
        if (option == drinkMade)
        {
            Debug.Log("Sucess");
        }
        else
        {
            Debug.Log("Fail");
        }
    }

    private void Update()
    {
        glasses = Physics.OverlapSphere(transform.position, radius, glassMask);

        foreach (Collider col in glasses)
        {
            if (glasses.Length == 1)
            {
                _glassObject = col.GetComponentInParent<Transform>();
                _glassObject.transform.position = glassPos.position;
                glassPlaced = true;
                col.attachedRigidbody.isKinematic = true;

                drink = col.GetComponentInChildren<SetDrinkType>();
                drinkMade = drink.option;

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    CheckOrder();
                }
                
            }
        }

        if (glasses.Length <= 0)
        {
            //hasOrdered = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hasOrdered)
        {
            AskForDrink();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
