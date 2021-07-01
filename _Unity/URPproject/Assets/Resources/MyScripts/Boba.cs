using UnityEngine;

public class Boba : MonoBehaviour
{
    public int nPearls;
    public int pearlsType;
    public int nPowders;
    public int powdersType;
    public int nTeas;
    public int TeasType;
    public int nToppings;
    public int ToppingsType;
    public bool Ice;

    public struct Drink
    {

    }

    public Drink order;

    //public void CreateDrink(Drink _drink)
    //{
    //    order.nPearls = _drink.nPearls;
    //    order.pearls = _drink.pearls;
    //    order.nPowders = _drink.nPowders;
    //    order.powders = _drink.powders;
    //    order.nTeas = _drink.nTeas;
    //    order.Teas = _drink.Teas;
    //    order.nToppings = _drink.nToppings;
    //    order.Toppings = _drink.Toppings;
    //    order.Ice = _drink.Ice;

    //}
    private void Update()
    {
    }
}