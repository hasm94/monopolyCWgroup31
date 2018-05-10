using System;

public class Utility : Purchasable
{

    public Utility(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        rent = r;
    }

    new public void PayRent(Player player)
    {
        int[] cRoll = player.diceRoller.GetRoll();
        int rollSum = cRoll[1] + cRoll[2];
        int ownsNoOfStreet = player.OwnsNoStreet(street);
        int mult = 4;
        if (ownsNoOfStreet == 2)
        {
            mult = 10;
        }
        else
            player.Spends(rollSum * mult);
        owner.Earns(rollSum * mult);
    }
}
