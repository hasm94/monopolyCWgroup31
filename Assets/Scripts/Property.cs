using UnityEngine;
using System;
using System.Collections;

public class Property : Purchasable
{

    int numberOfHouses;

    public Property(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        name = n;
        rent = r;
        numberOfHouses = 0;

    }

    new public void PayRent(Player player)
    {
        player.Spends(base.rent[numberOfHouses]);
    }

    public void BuildHouse()
    {
        numberOfHouses++;
        owner.Spends(street.GetHouseCost());
    }

    public void SellHouse()
    {
        numberOfHouses--;
        owner.Earns(street.GetHouseCost());
    }

    public int GetNumberOfHouses()
    {
        return numberOfHouses;
    }
}
