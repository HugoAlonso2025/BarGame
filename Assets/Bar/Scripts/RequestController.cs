using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RequestController : MonoBehaviour
{

    public int option;
    [SerializeField]  int drinkMade;

    public bool hasOrdered = false;
    public bool glassPlaced = false;
    public bool isTaken = false;
    public bool isTable;
    public bool sucess;
    public bool fail;

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
    CubesOnGlass cubes;
    LimeOnGlass lime;



    public void AskForDrink()
    {
        option = Random.Range(0, 24);
        if(!hasOrdered)
        {
            switch(option)
            {

                case 0:

                    hasOrdered = true;
                    Debug.Log("Quiero un azul");
                    break;

                case 1:

                    hasOrdered = true;
                    Debug.Log("Quiero un azul con hielo");
                    break;

                case 2:

                    hasOrdered = true;
                    Debug.Log("Quiero un azul con lima");
                    break;

                case 3:

                    hasOrdered = true;
                    Debug.Log("Quiero un azul con hielo y lima");
                    break;

                case 4:

                    hasOrdered = true;
                    Debug.Log("Quiero un rojo");
                    break;

                case 5:

                    hasOrdered = true;
                    Debug.Log("Quiero un rojo con hielo");
                    break;

                case 6:

                    hasOrdered = true;
                    Debug.Log("Quiero un rojo con lima");
                    break;

                case 7:

                    hasOrdered = true;
                    Debug.Log("Quiero un rojo con hielo y lima");
                    break;

                case 8:

                    hasOrdered = true;
                    Debug.Log("Quiero un amarillo");
                    break;

                case 9:

                    hasOrdered = true;
                    Debug.Log("Quiero un amarillo con hielo");
                    break;

                case 10:

                    hasOrdered = true;
                    Debug.Log("Quiero un amarillo con lima");
                    break;

                case 11:

                    hasOrdered = true;
                    Debug.Log("Quiero un amarillo con hielo y lima");
                    break;

                case 12:

                    hasOrdered = true;
                    Debug.Log("Quiero un naranja");
                    break;

                case 13:

                    hasOrdered = true;
                    Debug.Log("Quiero un naranja con hielo");
                    break;

                case 14:

                    hasOrdered = true;
                    Debug.Log("Quiero un naranja con lima");
                    break;

                case 15:

                    hasOrdered = true;
                    Debug.Log("Quiero un naranja con hielo y lima");
                    break;

                case 16:

                    hasOrdered = true;
                    Debug.Log("Quiero un verde");
                    break;

                case 17:

                    hasOrdered = true;
                    Debug.Log("Quiero un verde con hielo");
                    break;

                case 18:

                    hasOrdered = true;
                    Debug.Log("Quiero un verde con lima");
                    break;

                case 19:

                    hasOrdered = true;
                    Debug.Log("Quiero un verde con hielo y lima");
                    break;

                case 20:

                    hasOrdered = true;
                    Debug.Log("Quiero un morado");
                    break;

                case 21:

                    hasOrdered = true;
                    Debug.Log("Quiero un morado con hielo");
                    break;

                case 22:

                    hasOrdered = true;
                    Debug.Log("Quiero un morado con lima");
                    break;
                
                case 23:

                    hasOrdered = true;
                    Debug.Log("Quiero un morado con hielo y lima");
                    break;

                default:

                    Debug.Log("AAA");
                    break;
            }  
        }
    }

    void CheckOrder()
    {
        if (option == drinkMade)
        {
            Debug.Log("Sucess");
            sucess = true;

        }
        else
        {
            Debug.Log("Fail");
            fail = true;
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
                cubes = col.GetComponentInChildren<CubesOnGlass>();
                lime = col.GetComponentInChildren<LimeOnGlass>();

                if(cubes != null)
                {
                    cubes.CubesCheck();
                    lime.LimeCheck();
                }

                rb = col.attachedRigidbody;

                if (drink != null && hasOrdered && !rb.isKinematic)
                {
                    col.transform.position = glassPos.position;
                    col.transform.rotation = Quaternion.identity;
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
