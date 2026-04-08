using UnityEngine;

public class IceShovel : MonoBehaviour
{
    [SerializeField] Transform areaPos;

    [SerializeField] GameObject[] cubes;

    bool isEmpty;

    [SerializeField] LayerMask iceArea;
    [SerializeField] float radius;

    void CheckShovelStatus()
    {
        foreach(GameObject obj in cubes)
        {
            if( obj == null )
            {
                Debug.Log("Empty");
                isEmpty = true;
            }
            else
            {
                Debug.Log("Filled");
                isEmpty = false;
            }
        }
    }

    void OnIceAreaEntered()
    {
        if(Physics.CheckSphere(areaPos.position, radius, iceArea))
        {
            for(int i = 0; i < cubes.Length; i++)
            {
                cubes[i].SetActive(true);
            }
        }
    }

    private void Update()
    {
        //CheckShovelStatus();
        OnIceAreaEntered();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;   
        Gizmos.DrawWireSphere(areaPos.position, radius);
    }
}
