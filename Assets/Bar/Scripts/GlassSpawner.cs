using UnityEngine;

public class GlassSpawner : MonoBehaviour
{
    [SerializeField] GameObject glassPrefab;
    [SerializeField] GameObject cupPrefab;
    [SerializeField] GameObject limePrefab;
    [SerializeField] GameObject cupsGroup;
    [SerializeField] GameObject glassesGroup;
    [SerializeField] GameObject limeGroup;

    public void InstantiateGlass(Vector3 pos, Quaternion rot)
    {
        Instantiate(glassPrefab, pos, rot, glassesGroup.transform);
    }

    public void InstantiateCup(Vector3 pos, Quaternion rot)
    {
        Instantiate(cupPrefab, pos, rot, cupsGroup.transform);
    }

    public void InstantiateLime(Vector3 pos, Quaternion rot)
    {
        Instantiate(limePrefab, pos, rot, limeGroup.transform);
    }
}
