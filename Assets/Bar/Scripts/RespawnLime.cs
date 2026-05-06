using UnityEngine;

public class RespawnLime : MonoBehaviour
{
    RecoverObject obj;
    GlassSpawner glassSpawner;

    private void Start()
    {
        obj = GetComponent<RecoverObject>();
        glassSpawner = FindAnyObjectByType<GlassSpawner>();
    }

    public void InstantiateLime()
    {
        glassSpawner.InstantiateLime(obj._objPos, obj._objRot);
    }
}
