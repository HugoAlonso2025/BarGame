using UnityEngine;

public class BottleAim : MonoBehaviour
{
    [SerializeField] GameObject liquidPrefab;
    [SerializeField] Transform _tipPosition;
    [SerializeField] Transform _waterPos;
    [SerializeField] float distanceRay;
    [SerializeField] LayerMask glassLayer;

    GameObject liquidGO;

    GlassFillingUp glass;

    private void Update()
    {
        RaycastHit hit;

        if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270)
        {
            if (liquidGO == null)
            {
                liquidGO = Instantiate(liquidPrefab, _waterPos.position, _waterPos.rotation, transform);
            }

            if (Physics.Raycast(_tipPosition.position, transform.up, out hit, distanceRay, glassLayer) && liquidGO != null)
            {
                glass = hit.collider.gameObject.GetComponentInChildren<GlassFillingUp>();
                glass.GetRay();
                //Debug.Log("Vaso");
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_tipPosition.position, transform.up);
    }
}
