using System.Collections;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform entryPos;
    bool coolDown = false;
    int counter = 0;
    Quaternion rotationNPC;

    private void Start()
    {
        InvokeRepeating("InstantiateCustomer", 0, 5);
        rotationNPC = entryPos.rotation;
    }

    void InstantiateCustomer()
    {
        if (!coolDown && counter <= 5)
        {
            StartCoroutine(TimeToSpawn());
        }
        
    }

    IEnumerator TimeToSpawn()
    {
        coolDown = true;
        Instantiate(customerPrefab, entryPos.position, rotationNPC);
        counter++;
        yield return new WaitForSeconds(5);
        coolDown = false;
    }


}
