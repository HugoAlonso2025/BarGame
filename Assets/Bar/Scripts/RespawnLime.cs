using UnityEngine;

public class RespawnLime : MonoBehaviour
{
    RecoverObject obj;
    [SerializeField] GameObject limePrefab;
    [SerializeField] Transform parent;

    private void Start()
    {
        obj = GetComponent<RecoverObject>();
    }

    public void InstantiateLime()
    {
        Instantiate(limePrefab, obj._objPos, obj._objRot, parent);
    }
}
