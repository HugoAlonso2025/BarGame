using UnityEngine;

public class BottleAim : MonoBehaviour
{
    [SerializeField] GameObject liquidPrefab;
    [SerializeField] Transform _tipPosition;
    [SerializeField] Transform _waterPos;
    [SerializeField] float distanceRay;
    [SerializeField] LayerMask glassLayer;


    bool liquidOn = false;
    GameObject liquidGO;

    private void Update()
    {
        RaycastHit hit;

        Debug.Log(transform.localEulerAngles.z);

        if (!liquidOn && liquidGO == null && transform.localEulerAngles.z >= 90 <= 270)
        {
            liquidGO = Instantiate(liquidPrefab, _waterPos.position, _waterPos.rotation, transform);
        }

        if (Physics.Raycast(_tipPosition.position, transform.up, out hit, distanceRay, glassLayer))
        {
            
                Debug.Log("Vaso");
        }
        else
        {
            if(liquidGO != null)
            {
                Destroy(liquidGO);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_tipPosition.position, transform.up);
    }
}
