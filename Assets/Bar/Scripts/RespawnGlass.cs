using UnityEngine;

public class RespawnGlass : MonoBehaviour
{
    RecoverObject obj;
    [SerializeField] GameObject glassPrefab;

    private void Start()
    {
        obj = GetComponent<RecoverObject>();
    }

    public void InstantiateGlass()
    {
        Instantiate(glassPrefab, obj._objPos, Quaternion.identity);
    }
}
