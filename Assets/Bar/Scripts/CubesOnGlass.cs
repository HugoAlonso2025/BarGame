using UnityEngine;

public class CubesOnGlass : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;

    public void ActivateCube()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            if (!cubes[i].activeSelf)
            {
                cubes[i].SetActive(true);
                Debug.Log("Cube");
                return;
            }
        }
    }
}
