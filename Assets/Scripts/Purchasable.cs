// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Superclass for all purchasable tiles by the player.</summary>
// ***********************************************************************
using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// Class Purchasable.
/// </summary>
public class Purchasable : Tile
{

    /// <summary>
    /// The property's cost
    /// </summary>
    protected int propertyCost;
    /// <summary>
    /// The owner of the property
    /// </summary>
    protected Player owner;
    /// <summary>
    /// The rent for each level of property
    /// </summary>
    protected int[] rent;
    /// <summary>
    /// The mortgage
    /// </summary>
    protected int mortgage;
    /// <summary>
    /// If the property is currrently mortgaged
    /// </summary>
    protected bool mortgaged;
    /// <summary>
    /// The street the property is on
    /// </summary>
    protected Street street;

    /// <summary>
    /// Initializes a new instance of the <see cref="Purchasable"/> class.
    /// </summary>
    /// <param name="n">The name of the property.</param>
    /// <param name="nt">The next tile on the board.</param>
    /// <param name="c">The cost of purchase.</param>
    /// <param name="st">The street.</param>
    public Purchasable(String n, Tile[] nt, int c, Street st) : base(n, nt)
    {
        propertyCost = c;
        owner = null;
        street = st;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Purchasable"/> class.
    /// </summary>
    /// <param name="n">The name of the property.</param>
    /// <param name="c">The cost of purchase.</param>
    /// <param name="st">The street.</param>
    public Purchasable(String n, int c, Street st) : base(n)
    {
        propertyCost = c;
        owner = null;
        street = st;
    }

    /// <summary>
    /// Determines whether this instance has an owner.
    /// </summary>
    /// <returns><c>true</c> if this instance has owner; otherwise, <c>false</c>.</returns>
    public bool HasOwner()
    {
        if (owner != null)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    /// <summary>
    /// Gets the owner object.
    /// </summary>
    /// <returns>Player.</returns>
    public Player GetOwner()
    {
        return owner;
    }


    /// <summary>
    /// Gets the bought by the specific player, changes owner, and adds this to the player's property.
    /// </summary>
    /// <param name="player">The player purchasing.</param>
    public void GetsBoughtBy(Player player)
    {

        if (player.getBalance() > propertyCost && owner == null)
        {

            player.Spends(propertyCost);

            owner = player;

            player.BuyTile(this);

        }
        else
        {

            Debug.Log("Player doesn't have enough money to buy this property");

        }

    }

    /// <summary>
    /// Sellses the property.
    /// </summary>
    public void SellsProperty()
    {

        owner = null;

        owner.Earns(propertyCost);

    }

    /// <summary>
    /// Mortgages the property.
    /// </summary>
    public void MortgageProp()
    {

        owner.Earns(mortgage);

        mortgaged = true;

    }

    /// <summary>
    /// Pays the off mortgage.
    /// </summary>
    public void PayOffMortgage()
    {

        owner.Spends(mortgage);

        mortgaged = false;

    }

    /// <summary>
    /// Gets the street that the property is on.
    /// </summary>
    /// <returns>Street.</returns>
    public Street GetStreet()
    {
        return street;
    }

    /// <summary>
    /// Pays the rent.
    /// </summary>
    /// <param name="player">The player who landed on the property.</param>
    public void PayRent(Player player)
    {

    }

    /// <summary>
    /// Determines whether this instance is purchasable.
    /// </summary>
    /// <returns><c>true</c> every time.</returns>
    public new bool IsPurchasable()
    {
        return true;
    }

    /// <summary>
    /// Determines whether this instance is mortgaged.
    /// </summary>
    /// <returns><c>true</c> if this instance is mortgaged; otherwise, <c>false</c>.</returns>
    public bool IsMortgaged()
    {
        return mortgaged;
    }



}
