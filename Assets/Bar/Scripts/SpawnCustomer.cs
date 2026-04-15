using System.Collections;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Transform entryPos;
    bool coolDown = false;
    int counter = 0;

    private void Start()
    {
        InvokeRepeating("InstantiateCustomer", 0, 5);
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
        Instantiate(customerPrefab, entryPos.position, Quaternion.identity);
        counter++;
        yield return new WaitForSeconds(5);
        coolDown = false;
    }


}
