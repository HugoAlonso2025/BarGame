using UnityEngine;

public class CubesOnGlass : MonoBehaviour
{
    [SerializeField] GameObject[] cubes;
    public bool cubesOn;

    public void ActivateCube()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            if (!cubes[i].activeSelf)
            {
                cubes[i].SetActive(true);
                return;
            }
        }
    }

    public void CubesCheck()
    {
        for(int i = 0; i < cubes.Length; i++)
        {
            if (cubes[i].activeSelf && i == cubes.Length - 1)
            {
                cubesOn = true;
            }
            else
            {
                cubesOn = false;
            }
        }
    }
}
