using UnityEngine;

public class SetDrinkType : MonoBehaviour
{
    public bool comb1Drink;
    public bool blueDrink;
    public bool redDrink;
    public bool mistakeDrink;

    public int option;

    void SetValueToOrder()
    {
        if (comb1Drink)
        {
            option = 3;
        }
        else if (blueDrink)
        {
            option = 2;
        }
        else if (redDrink)
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
