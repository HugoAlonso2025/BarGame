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

    private void Start()
    {
        cubes = GetComponent<CubesOnGlass>();
    }

    void SetValueToOrder()
    {
        
        if (purpleDrink && cubes.cubesOn)
        {
            option = 11;
        }
        if (purpleDrink && !cubes.cubesOn)
        {
            option = 10;
        }
        else if (greenDrink && cubes.cubesOn)
        {
            option = 9;
        }
        else if (greenDrink && !cubes.cubesOn)
        {
            option = 8;
        }
        else if (orangeDrink && cubes.cubesOn)
        {
            option = 7;
        }
        else if (orangeDrink && !cubes.cubesOn)
        {
            option = 6;
        }
        else if (yellowDrink && cubes.cubesOn)
        {
            option = 5;
        }
        else if (yellowDrink && !cubes.cubesOn)
        {
            option = 4;
        }
        else if (redDrink && cubes.cubesOn)
        {
            option = 3;
        }
        else if (redDrink)
        {
            option = 2;
        }
        else if (blueDrink && cubes.cubesOn)
        {
            option = 1;
        }
        else if (blueDrink && !cubes.cubesOn)
        {
            option = 0;
        }
        else if (mistakeDrink)
        {
            option = 6;
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
