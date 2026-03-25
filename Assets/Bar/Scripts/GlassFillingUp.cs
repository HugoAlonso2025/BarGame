using System.Collections;
using UnityEngine;

public class GlassFillingUp : MonoBehaviour
{
    [SerializeField] float waterPercentage = 0;
    bool coolDown = false;

    void FillGlass()
    {
        coolDown = false;
        waterPercentage += 20;
        Debug.Log(waterPercentage);
    }

    public void GetRay()
    {
        if (!coolDown)
        {
            StartCoroutine(WaitToFill());
        }
    }

    IEnumerator WaitToFill()
    {
        coolDown = true;
        yield return new WaitForSeconds(2);
        FillGlass();
    }

}
