// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Superclass for all non-purchasable tiles, action tiles or the corner tiles.</summary>
// ***********************************************************************
using UnityEngine;
using System.Collections;

/// <summary>
/// Class NonPurchasable.
/// </summary>
public class NonPurchasable : Tile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NonPurchasable"/> class.
    /// </summary>
    /// <param name="n">The name of the tile</param>
    public NonPurchasable(string n) : base(n)
    {

    }

    /// <summary>
    /// Completes the action. But should never be called
    /// </summary>
    public void CompleteAction()
    {
        Debug.Log("Nothing has happened, there is a mistake in the code that calls nonPurchasable, rather than the subclasses");
    }

    /// <summary>
    /// Determines whether this instance is purchasable.
    /// </summary>
    /// <returns><c>false</c> every time.</returns>
    new public bool IsPurchasable()
    {
        return false;
    }
}
