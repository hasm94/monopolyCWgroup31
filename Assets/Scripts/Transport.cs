// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Class to represent the transport tiles on the board, these can be train stations, airports, or harbours</summary>
// ***********************************************************************
using System;

/// <summary>
/// Class Transport.
/// </summary>
public class Transport : Purchasable
{

    /// <summary>
    /// Initializes a new instance of the <see cref="Transport"/> class.
    /// </summary>
    /// <param name="n">The name of the Transport tile</param>
    /// <param name="c">The ccost of the tile</param>
    /// <param name="r">The rent at different stages of progression</param>
    /// <param name="st">The street that the property belongs to</param>
    public Transport(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        rent = r;
    }

    /// <summary>
    /// Pays the rent to the owner of the property, takes the money out of the player's balance.
    /// </summary>
    /// <param name="player">The player that needs to pay the rent</param>
    new public void PayRent(Player player)
    {

        int ownsNoOfStreet = player.OwnsNoStreet(street);
        player.Spends(rent[ownsNoOfStreet - 1]);
    }

}
