using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFillingUp : MonoBehaviour
{
    public float waterPercentage;

    [SerializeField] float value;
    [SerializeField] float blueCount;
    [SerializeField] float redCount;
    [SerializeField] float yellowCount;

    Renderer rend;

    [SerializeField] Material _blueMat;
    [SerializeField] Material _redMat;
    [SerializeField] Material _yellowMat;
    [SerializeField] Material _combPurpleMat;
    [SerializeField] Material _combGreenMat;
    [SerializeField] Material _combOrgangeMat;
    [SerializeField] Material _errorMat;

    bool materialAsigned;

    SetDrinkType drink;

    bool blue = false;
    bool red = false;
    bool yellow = false;
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
            red = true;
            blue = false;
            yellow = false;
        }
        else if (other.tag == "blue")
        {
            blue = true;
            red = false;
            yellow = false;
        }
        else if (other.tag == "yellow")
        {
            red = false;
            blue = false;
            yellow = true;
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
                    
                if(blue)
                {
                    
                    if (isCup)
                    {
                        blueCount += 0.4f;
                        Debug.Log("Blue: " + blueCount);
                    }
                    else
                    {
                        blueCount += 0.25f;
                        Debug.Log("Blue: " + blueCount);
                    }
                }
                else if(red)
                {
                    if (isCup)
                    {
                        redCount += 0.4f;
                        Debug.Log("Red: " + redCount);
                    }
                    else
                    {
                        redCount += 0.25f;
                        Debug.Log("Red: " + redCount);
                    }  
                }
                else if (yellow)
                {
                    if (isCup)
                    {
                        yellowCount += 0.4f;
                        Debug.Log("Yellow: " + yellowCount);
                    }
                    else
                    {
                        redCount += 0.25f;
                        Debug.Log("Yellow: " + yellowCount);
                    }
                }
            }
        }
        if (waterPercentage > 0 && !materialAsigned)
        {
            materialAsigned = true;
            if (blue)
            {
                rend.material = _blueMat;
            }
            else if (red)
            {
                rend.material = _redMat;
            }
            else if (yellow)
            {
                rend.material = _yellowMat;
            }
        }

        if (waterPercentage >= 100 && !drinkFinished)
        {
            drinkFinished = true;

            if (blueCount >= 45 && blueCount < 55 && redCount >= 45 && redCount < 55)
            {
                Debug.Log("Purple");
                drink.purpleDrink = true;
                rend.material = _combPurpleMat;
            }
            else if (blueCount >= 45 && blueCount < 55 && yellowCount >= 45 && yellowCount < 55)
            {
                Debug.Log("Green");
                drink.greenDrink = true;
                rend.material = _combGreenMat;
            }
            else if (redCount >= 45 && redCount < 55 && yellowCount >= 45 && yellowCount < 55)
            {
                Debug.Log("Orange");
                drink.orangeDrink = true;
                rend.material = _combOrgangeMat;
            }
            else if (blueCount >= 90)
            {
                Debug.Log("Blue");
                drink.blueDrink = true;
                rend.material = _blueMat;
            }
            else if (redCount >= 90)
            {
                Debug.Log("Red");
                drink.redDrink = true;
                rend.material = _redMat;
            }
            else if (yellowCount >= 90)
            {
                Debug.Log("Yellow");
                drink.redDrink = true;
                rend.material = _yellowMat;
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
