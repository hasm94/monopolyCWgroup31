using UnityEngine;
using System.Collections;

public class NonPurchasable : Tile
{
    public NonPurchasable(string n) : base(n)
    {

    }

    public void CompleteAction()
    {
        Debug.Log("Nothing has happened, there is a mistake in the code that calls nonPurchasable, rather than the subclasses");
    }

    new public bool IsPurchasable()
    {
        return false;
    }
}
