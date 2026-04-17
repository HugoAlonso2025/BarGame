using UnityEngine;

public class BottleAim : MonoBehaviour
{
    [SerializeField] GameObject liquidPrefab;
    [SerializeField] Transform _waterPos;
    [SerializeField] LayerMask glassLayer;
    Rigidbody rb;

    GameObject liquidGO;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270 && rb.isKinematic)
        {
            if (liquidGO == null)
            {
                liquidGO = Instantiate(liquidPrefab, _waterPos.position, _waterPos.rotation, transform);
            }
        }
        else
        {
            if(liquidGO != null)
            {
                Destroy(liquidGO);
            }
           
        }
    }
}
