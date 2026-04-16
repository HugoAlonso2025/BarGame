using UnityEngine;

public class BottleAim : MonoBehaviour
{
    [SerializeField] GameObject liquidPrefab;
    [SerializeField] Transform _waterPos;
    [SerializeField] LayerMask glassLayer;

    GameObject liquidGO;

    private void Update()
    {
        RaycastHit hit;

        if (transform.localEulerAngles.z > 90 && transform.localEulerAngles.z < 270)
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
