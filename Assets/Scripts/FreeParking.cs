using UnityEngine;

public class FreeParking : NonPurchasable
{

    public FreeParking(string n) : base(n)
    {

    }

    public void CompleteAction(Player p)
    {
        Debug.Log("Player has received the free parking fines");

    }

}
