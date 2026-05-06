using UnityEngine;

public class RespawnGlass : MonoBehaviour
{
    RecoverObject obj;
    GlassFillingUp glass;
    GlassSpawner glassSpawner;

    private void Start()
    {
        obj = GetComponent<RecoverObject>();
        glass = GetComponentInChildren<GlassFillingUp>();
        glassSpawner = FindAnyObjectByType<GlassSpawner>();
    }

    public void InstantiateGlass()
    {
        if (glass.isCup)
        {
            glassSpawner.InstantiateCup(obj._objPos, obj._objRot);
        }
        else
        {
            glassSpawner.InstantiateGlass(obj._objPos, obj._objRot);
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "trash")
        {
            if (glass.isCup)
            {
                glassSpawner.InstantiateCup(obj._objPos, obj._objRot);
                Destroy(gameObject);
            }
            else
            {
                glassSpawner.InstantiateGlass(obj._objPos, obj._objRot);
                Destroy(gameObject);
            }
        }
    }
}
