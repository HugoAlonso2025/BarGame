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
            option = 6;
        }
        else if (greenDrink)
        {
            option = 5;
        }
        else if (orangeDrink)
        {
            option = 4;
        }
        else if (yellowDrink)
        {
            option = 3;
        }
        else if (redDrink)
        {
            option = 2;
        }
        else if (blueDrink)
        {
            option = 1;
        }
        else if (mistakeDrink)
        {
            option = 0;
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
