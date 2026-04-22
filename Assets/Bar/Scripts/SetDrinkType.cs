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

    void SetValueToOrder()
    {
        if (purpleDrink)
        {
            option = 5;
        }
        else if (greenDrink)
        {
            option = 4;
        }
        else if (orangeDrink)
        {
            option = 3;
        }
        else if (yellowDrink)
        {
            option = 2;
        }
        else if (redDrink)
        {
            option = 1;
        }
        else if (blueDrink)
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
