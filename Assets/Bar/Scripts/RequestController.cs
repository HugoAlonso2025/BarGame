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
    public bool hasDelivered;

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
        option = Random.Range(0, 48);
        if(!hasOrdered)
        {
            switch(option)
            {

                // VASO
                case 0: hasOrdered = true; Debug.Log("Quiero un azul en vaso"); break;
                case 1: hasOrdered = true; Debug.Log("Quiero un azul con hielo en vaso"); break;
                case 2: hasOrdered = true; Debug.Log("Quiero un azul con lima en vaso"); break;
                case 3: hasOrdered = true; Debug.Log("Quiero un azul con hielo y lima en vaso"); break;

                case 4: hasOrdered = true; Debug.Log("Quiero un rojo en vaso"); break;
                case 5: hasOrdered = true; Debug.Log("Quiero un rojo con hielo en vaso"); break;
                case 6: hasOrdered = true; Debug.Log("Quiero un rojo con lima en vaso"); break;
                case 7: hasOrdered = true; Debug.Log("Quiero un rojo con hielo y lima en vaso"); break;

                case 8: hasOrdered = true; Debug.Log("Quiero un amarillo en vaso"); break;
                case 9: hasOrdered = true; Debug.Log("Quiero un amarillo con hielo en vaso"); break;
                case 10: hasOrdered = true; Debug.Log("Quiero un amarillo con lima en vaso"); break;
                case 11: hasOrdered = true; Debug.Log("Quiero un amarillo con hielo y lima en vaso"); break;

                case 12: hasOrdered = true; Debug.Log("Quiero un naranja en vaso"); break;
                case 13: hasOrdered = true; Debug.Log("Quiero un naranja con hielo en vaso"); break;
                case 14: hasOrdered = true; Debug.Log("Quiero un naranja con lima en vaso"); break;
                case 15: hasOrdered = true; Debug.Log("Quiero un naranja con hielo y lima en vaso"); break;

                case 16: hasOrdered = true; Debug.Log("Quiero un verde en vaso"); break;
                case 17: hasOrdered = true; Debug.Log("Quiero un verde con hielo en vaso"); break;
                case 18: hasOrdered = true; Debug.Log("Quiero un verde con lima en vaso"); break;
                case 19: hasOrdered = true; Debug.Log("Quiero un verde con hielo y lima en vaso"); break;

                case 20: hasOrdered = true; Debug.Log("Quiero un morado en vaso"); break;
                case 21: hasOrdered = true; Debug.Log("Quiero un morado con hielo en vaso"); break;
                case 22: hasOrdered = true; Debug.Log("Quiero un morado con lima en vaso"); break;
                case 23: hasOrdered = true; Debug.Log("Quiero un morado con hielo y lima en vaso"); break;

                // COPA
                case 24: hasOrdered = true; Debug.Log("Quiero un azul en copa"); break;
                case 25: hasOrdered = true; Debug.Log("Quiero un azul con hielo en copa"); break;
                case 26: hasOrdered = true; Debug.Log("Quiero un azul con lima en copa"); break;
                case 27: hasOrdered = true; Debug.Log("Quiero un azul con hielo y lima en copa"); break;

                case 28: hasOrdered = true; Debug.Log("Quiero un rojo en copa"); break;
                case 29: hasOrdered = true; Debug.Log("Quiero un rojo con hielo en copa"); break;
                case 30: hasOrdered = true; Debug.Log("Quiero un rojo con lima en copa"); break;
                case 31: hasOrdered = true; Debug.Log("Quiero un rojo con hielo y lima en copa"); break;

                case 32: hasOrdered = true; Debug.Log("Quiero un amarillo en copa"); break;
                case 33: hasOrdered = true; Debug.Log("Quiero un amarillo con hielo en copa"); break;
                case 34: hasOrdered = true; Debug.Log("Quiero un amarillo con lima en copa"); break;
                case 35: hasOrdered = true; Debug.Log("Quiero un amarillo con hielo y lima en copa"); break;

                case 36: hasOrdered = true; Debug.Log("Quiero un naranja en copa"); break;
                case 37: hasOrdered = true; Debug.Log("Quiero un naranja con hielo en copa"); break;
                case 38: hasOrdered = true; Debug.Log("Quiero un naranja con lima en copa"); break;
                case 39: hasOrdered = true; Debug.Log("Quiero un naranja con hielo y lima en copa"); break;

                case 40: hasOrdered = true; Debug.Log("Quiero un verde en copa"); break;
                case 41: hasOrdered = true; Debug.Log("Quiero un verde con hielo en copa"); break;
                case 42: hasOrdered = true; Debug.Log("Quiero un verde con lima en copa"); break;
                case 43: hasOrdered = true; Debug.Log("Quiero un verde con hielo y lima en copa"); break;

                case 44: hasOrdered = true; Debug.Log("Quiero un morado en copa"); break;
                case 45: hasOrdered = true; Debug.Log("Quiero un morado con hielo en copa"); break;
                case 46: hasOrdered = true; Debug.Log("Quiero un morado con lima en copa"); break;
                case 47: hasOrdered = true; Debug.Log("Quiero un morado con hielo y lima en copa"); break;

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

                if (drink != null && hasOrdered && !rb.isKinematic && !hasDelivered)
                {
                    hasDelivered = true;
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
