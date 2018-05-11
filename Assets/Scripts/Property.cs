// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>A specific property, can have houses and hotels buiolt on it.</summary>
// ***********************************************************************
using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Class Property.
/// </summary>
public class Property : Purchasable
{

    /// <summary>
    /// The number of houses
    /// </summary>
    int numberOfHouses;

    /// <summary>
    /// Initializes a new instance of the <see cref="Property"/> class.
    /// </summary>
    /// <param name="n">The name of the property.</param>
    /// <param name="c">The cost of purtchase.</param>
    /// <param name="r">The rent.</param>
    /// <param name="st">The street.</param>
    public Property(String n, int c, int[] r, Street st) : base(n, c, st)
    {
        name = n;
        rent = r;
        numberOfHouses = 0;

    }

    /// <summary>
    /// Pays the rent.
    /// </summary>
    /// <param name="player">The player who needs to pay.</param>
    new public void PayRent(Player player)
    {
        player.Spends(base.rent[numberOfHouses]);
    }

    /// <summary>
    /// Builds a house on the property.
    /// </summary>
    public void BuildHouse()
    {
        numberOfHouses++;
        owner.Spends(street.GetHouseCost());
    }

    /// <summary>
    /// Sells a house.
    /// </summary>
    public void SellHouse()
    {
        numberOfHouses--;
        owner.Earns(street.GetHouseCost());
    }

    /// <summary>
    /// Gets the number of houses on the street.
    /// </summary>
    /// <returns>System.Int32.</returns>
    public int GetNumberOfHouses()
    {
        return numberOfHouses;
    }
}
