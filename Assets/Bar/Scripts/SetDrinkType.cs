using UnityEngine;

public class SetDrinkType : MonoBehaviour
{
    public bool purpleDrink;
    public bool blueDrink;
    public bool redDrink;
    public bool yellowDrink;
    public bool greenDrink;
    public bool orangeDrink;
    public bool mistakeDrink;

    public int option;

    CubesOnGlass cubes;
    LimeOnGlass lime;

    private void Start()
    {
        cubes = GetComponent<CubesOnGlass>();
        lime = GetComponent<LimeOnGlass>();
    }

    void SetValueToOrder()
    {

        if (purpleDrink && cubes.cubesOn && lime.limeOn)
        {
            option = 23;
        }
        if (purpleDrink && !cubes.cubesOn && lime.limeOn)
        {
            option = 22;
        }
        if (purpleDrink && cubes.cubesOn && !lime.limeOn)
        {
            option = 21;
        }
        if (purpleDrink && !cubes.cubesOn && !lime.limeOn)
        {
            option = 20;
        }
        else if (greenDrink && cubes.cubesOn && lime.limeOn)
        {
            option = 19;
        }
        else if (greenDrink && !cubes.cubesOn && lime.limeOn)
        {
            option = 18;
        }
        else if (greenDrink && cubes.cubesOn && !lime.limeOn)
        {
            option = 17;
        }
        else if (greenDrink && !cubes.cubesOn && !lime.limeOn)
        {
            option = 16;
        }
        else if (orangeDrink && cubes.cubesOn && lime.limeOn)
        {
            option = 15;
        }
        else if (orangeDrink && !cubes.cubesOn && lime.limeOn)
        {
            option = 14;
        }
        else if (orangeDrink && cubes.cubesOn && !lime.limeOn)
        {
            option = 13;
        }
        else if (orangeDrink && !cubes.cubesOn && !lime.limeOn)
        {
            option = 12;
        }
        else if (yellowDrink && cubes.cubesOn && lime.limeOn)
        {
            option = 11;
        }
        else if (yellowDrink && !cubes.cubesOn && lime.limeOn)
        {
            option = 10;
        }
        else if (yellowDrink && cubes.cubesOn && !lime.limeOn)
        {
            option = 9;
        }
        else if (yellowDrink && !cubes.cubesOn && !lime.limeOn)
        {
            option = 8;
        }
        
        else if (redDrink && cubes.cubesOn && lime.limeOn)
        {
            option = 7;
        }
        else if (redDrink && !cubes.cubesOn && lime.limeOn)
        {
            option = 6;
        }
        else if (redDrink && cubes.cubesOn && !lime.limeOn)
        {
            option = 5;
        }
        else if (redDrink && !cubes.cubesOn && !lime.limeOn)
        {
            option = 4;
        }
        else if (blueDrink && cubes.cubesOn && lime.limeOn)
        {
            option = 3;
        }
        else if (blueDrink && !cubes.cubesOn && lime.limeOn )
        {
            option = 2;
        }
        else if (blueDrink && cubes.cubesOn && !lime.limeOn)
        {
            option = 1;
        }
        else if (blueDrink && !cubes.cubesOn && !lime.limeOn)
        {
            option = 0;
        }
        else if (mistakeDrink)
        {
            option = 24;
        }
    }

    private void Update()
    {
        SetValueToOrder();
    }

    public int GetDrinkMade(int choice)
    {
        return choice = option;
    }
}
