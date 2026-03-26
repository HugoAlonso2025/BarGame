using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFillingUp : MonoBehaviour
{
    public float waterPercentage;
    //bool coolDown = false;

    //void FillGlass()
    //{
    //    if (waterPercentage < 100)
    //    {
    //        coolDown = false;
    //        waterPercentage += 20;
    //        Debug.Log(waterPercentage);
    //    }

        
    //}

    //public void StopFilling()
    //{
    //    StopAllCoroutines();
    //}

    //public void GetRay()
    //{
    //    if (!coolDown)
    //    {
    //        StartCoroutine(WaitToFill());
    //    }
    //}

    //IEnumerator WaitToFill()
    //{
    //    coolDown = true;
    //    yield return new WaitForSeconds(2);
    //    FillGlass();
    //}

    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = other.GetComponent<ParticleSystem>();
        int count = ps.GetCollisionEvents(gameObject, collisionEvents);

        if(waterPercentage < 100)
        {
            for (int i = 0; i < count; i++)
            {
                waterPercentage += 5;
                Debug.Log(waterPercentage);
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
