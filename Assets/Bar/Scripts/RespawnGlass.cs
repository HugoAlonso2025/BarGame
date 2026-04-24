using UnityEngine;

public class RespawnGlass : MonoBehaviour
{
    RecoverObject obj;
    [SerializeField] GameObject glassPrefab;
    [SerializeField] Transform parent;

    private void Start()
    {
        obj = GetComponent<RecoverObject>();
    }

    public void InstantiateGlass()
    {
        Instantiate(glassPrefab, obj._objPos, obj._objRot, parent);
    }
}
