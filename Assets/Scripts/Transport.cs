using System;

public class Transport : Purchasable
{

    public Transport(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        rent = r;
    }

    new public void PayRent(Player player)
    {

        int ownsNoOfStreet = player.OwnsNoStreet(street);
        player.Spends(rent[ownsNoOfStreet - 1]);
    }

}
