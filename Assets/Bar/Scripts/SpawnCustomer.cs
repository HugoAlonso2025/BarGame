using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform entryPos;
    bool coolDown = false;
    public int counter = 0;
    Quaternion rotationNPC;

    private void Start()
    {
        rotationNPC = entryPos.rotation;
    }

    void InstantiateCustomer()
    {
        if (!coolDown && counter < 4)
        {
            StartCoroutine(TimeToSpawn());
        }
        
    }

    private void Update()
    {
        InstantiateCustomer();
    }

    IEnumerator TimeToSpawn()
    {
        coolDown = true;
        yield return new WaitForSeconds(2);
        Instantiate(customerPrefab, entryPos.position, rotationNPC);
        counter++;
        yield return new WaitForSeconds(20);
        coolDown = false;
    }


}
