using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RequestController : MonoBehaviour
{

    [SerializeField]  int option;
    [SerializeField]  int drinkMade;

    public bool hasOrdered = false;
    public bool glassPlaced = false;
    public bool isTaken = false;
    public bool isTable;

    [SerializeField] float radius;

    [SerializeField] Transform glassPos;

    [SerializeField] LayerMask glassMask;

    [SerializeField] string textRequest;
    [SerializeField] float timeLapse;

    Collider[] glasses;
    public Transform[] positions;

    public GameObject _glassObject;
    Rigidbody rb;

    SetDrinkType drink;



    public void AskForDrink()
    {
        option = Random.Range(0, 3);
        if(!hasOrdered)
        {
            switch(option)
            {
                case 0:

                    hasOrdered = true;
                    Debug.Log("Quiero un error");
                    break;

                case 1:

                    hasOrdered = true;
                    Debug.Log("Quiero un rojo");
                    break;

                case 2:

                    hasOrdered = true;
                    Debug.Log("Quiero un azul");
                    break;

                case 3:

                    hasOrdered = true;
                    Debug.Log("Quiero un combi");
                    break;
            }  
        }
    }

    void CheckOrder()
    {
        if (option == drinkMade)
        {
            Debug.Log("Sucess");
            //_glassObject.gameObject.SetActive(false);

        }
        else
        {
            Debug.Log("Fail");
            //_glassObject.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        glasses = Physics.OverlapSphere(transform.position, radius, glassMask);

        foreach (Collider col in glasses)
        {
            if (glasses.Length == 1)
            {
                _glassObject = col.gameObject;
                drink = col.GetComponentInChildren<SetDrinkType>();

                rb = col.attachedRigidbody;

                if (drink != null && hasOrdered && !rb.isKinematic)
                {
                    col.transform.position = glassPos.position;
                    glassPlaced = true;
                    col.attachedRigidbody.isKinematic = true;

                    drinkMade = drink.option;
                    CheckOrder();
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
