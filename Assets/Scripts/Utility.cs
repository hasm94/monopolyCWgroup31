// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Class to fill in the two utility tiles on board, with a special payRent method</summary>
// ***********************************************************************
using System;

/// <summary>
/// Class Utility.
/// </summary>
public class Utility : Purchasable
{

    /// <summary>
    /// Initializes a new instance of the <see cref="Utility"/> class.
    /// </summary>
    /// <param name="n">The name of the Utility tile</param>
    /// <param name="c">The ccost of the tile</param>
    /// <param name="r">The rent at different stages of progression</param>
    /// <param name="st">The street that the property belongs to</param>
    public Utility(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        rent = r;
    }

    /// <summary>
    /// Pays the rent to the owner of the property, takes the money out of the player's balance.
    /// </summary>
    /// <param name="player">The player that needs to pay the rent</param>
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
