using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFillingUp : MonoBehaviour
{
    public float waterPercentage;

    [SerializeField] float value;
    [SerializeField] float normalCount;
    [SerializeField] float altCount;
    Renderer rend;
    [SerializeField] Material _normalMat;
    [SerializeField] Material _altMat;
    [SerializeField] Material _combMat;
    [SerializeField] Material _errorMat;
    bool materialAsigned;

    Rigidbody rb;

    SetDrinkType drink;

    bool normal = false;
    bool alt = false;
    bool drinkFinished = false;
    [SerializeField] bool isCup = false;

    private List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

    void Start()
    {
        if (isCup)
        {
            value = -0.026f;
        }
        else
        {
            value = -0.07f;
        }
        rb = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        drink = GetComponent<SetDrinkType>();
    }

    void Update()
    {
        rend.material.SetFloat("_Fill", value);
    }

    void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = other.GetComponent<ParticleSystem>();

        if(other.tag == "red")
        {
            alt = true;
            normal = false;
        }
        else if (other.tag == "normal")
        {
            normal = true;
            alt = false;
        }

        int count = ps.GetCollisionEvents(gameObject, collisionEvents);

        if(waterPercentage < 100)
        {
            for (int i = 0; i < count; i++)
            {
                if(isCup)
                {
                    waterPercentage += 0.4f;
                    value += 0.00014f;
                }
                else
                {
                    waterPercentage += 0.25f;
                    value += 0.00025f;
                }
                    
                if(normal)
                {
                    
                    if (isCup)
                    {
                        normalCount += 0.4f;
                        Debug.Log("ALt: " + normalCount);
                    }
                    else
                    {
                        normalCount += 0.25f;
                        Debug.Log("Normal: " + normalCount);
                    }
                }
                else if(alt)
                {
                    if (isCup)
                    {
                        altCount += 0.4f;
                        Debug.Log("ALt: " + altCount);
                    }
                    else
                    {
                        altCount += 0.25f;
                        Debug.Log("ALt: " + altCount);
                    }
                    
                }
            }
        }
        if (waterPercentage > 0 && !materialAsigned)
        {
            materialAsigned = true;
            if (normal)
            {
                rend.material = _normalMat;
            }
            else if (alt)
            {
                rend.material = _altMat;
            }
        }

        if (waterPercentage >= 100 && !drinkFinished)
        {
            drinkFinished = true;

            if (normalCount >= 45 && normalCount < 55 && altCount >= 45 && altCount < 55)
            {
                Debug.Log("Comb");
                drink.comb1Drink = true;
                rend.material = _combMat;
            }
            else if (normalCount >= 90)
            {
                Debug.Log("Normal");
                drink.blueDrink = true;
                rend.material = _normalMat;
            }
            else if (altCount >= 90)
            {
                Debug.Log("Alt");
                drink.redDrink = true;
                rend.material = _altMat;
            }
            else
            {
                Debug.Log("Error");
                drink.mistakeDrink = true;
                rend.material = _errorMat;
            }
        }
    }
}
