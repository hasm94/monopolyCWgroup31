// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Represents the Free Parking tile</summary>
// ***********************************************************************
using UnityEngine;

/// <summary>
/// Class FreeParking.
/// </summary>
public class FreeParking : NonPurchasable
{

    /// <summary>
    /// Initializes a new instance of the <see cref="FreeParking"/> class.
    /// </summary>
    /// <param name="n">The n.</param>
    public FreeParking(string n) : base(n)
    {

    }

    /// <summary>
    /// Resets the free parking fines, and the player receives all of them.
    /// </summary>
    /// <param name="p">The p.</param>
    public void CompleteAction(Player p)
    {
        Debug.Log("Player has received the free parking fines");

    }

}
