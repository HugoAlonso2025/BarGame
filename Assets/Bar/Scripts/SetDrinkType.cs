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
    GlassFillingUp glass;

    private void Start()
    {
        cubes = GetComponent<CubesOnGlass>();
        lime = GetComponent<LimeOnGlass>();
        glass = GetComponent<GlassFillingUp>();
    }

    void SetValueToOrder()
    {
        if (purpleDrink && cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 47;
        }
        if (purpleDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 46;
        }
        if (purpleDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 45;
        }
        if (purpleDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 44;
        }
        else if (greenDrink && cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 43;
        }
        else if (greenDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 42;
        }
        else if (greenDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 41;
        }
        else if (greenDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 40;
        }
        else if (orangeDrink && cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 39;
        }
        else if (orangeDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 38;
        }
        else if (orangeDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 37;
        }
        else if (orangeDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 36;
        }
        else if (yellowDrink && cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 35;
        }
        else if (yellowDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 34;
        }
        else if (yellowDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 33;
        }
        else if (yellowDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 32;
        }
        else if (redDrink && cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 31;
        }
        else if (redDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 30;
        }
        else if (redDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 29;
        }
        else if (redDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 28;
        }
        else if (blueDrink && cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 27;
        }
        else if (blueDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == true)
        {
            option = 26;
        }
        else if (blueDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 25;
        }
        else if (blueDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == true)
        {
            option = 24;
        }

        if (purpleDrink && cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 23;
        }
        if (purpleDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 22;
        }
        if (purpleDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 21;
        }
        if (purpleDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 20;
        }
        else if (greenDrink && cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 19;
        }
        else if (greenDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 18;
        }
        else if (greenDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 17;
        }
        else if (greenDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 16;
        }
        else if (orangeDrink && cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 15;
        }
        else if (orangeDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 14;
        }
        else if (orangeDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 13;
        }
        else if (orangeDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 12;
        }
        else if (yellowDrink && cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 11;
        }
        else if (yellowDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 10;
        }
        else if (yellowDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 9;
        }
        else if (yellowDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 8;
        }
        else if (redDrink && cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 7;
        }
        else if (redDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 6;
        }
        else if (redDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 5;
        }
        else if (redDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 4;
        }
        else if (blueDrink && cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 3;
        }
        else if (blueDrink && !cubes.cubesOn && lime.limeOn && glass.isCup == false)
        {
            option = 2;
        }
        else if (blueDrink && cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 1;
        }
        else if (blueDrink && !cubes.cubesOn && !lime.limeOn && glass.isCup == false)
        {
            option = 0;
        }
        else if (mistakeDrink && glass.isCup == false)
        {
            option = 48;
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
