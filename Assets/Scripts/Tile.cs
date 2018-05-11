// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Abstract representation of each of the tiles on board.</summary>
// ***********************************************************************
using UnityEngine;
using System;

/// <summary>
/// Class Tile.
/// </summary>
public class Tile : MonoBehaviour
{

    /// <summary>
    /// The tile name
    /// </summary>
    private String tileName;
    /// <summary>
    /// The next tile on the board
    /// </summary>
    private Tile[] nextTile;

    /// <summary>
    /// Initializes a new instance of the <see cref="Tile"/> class.
    /// </summary>
    /// <param name="n">The name of the tile</param>
    /// <param name="nt">The Next tile</param>
    public Tile(String n, Tile[] nt)
    {
        tileName = n;
        nextTile = nt;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tile"/> class. This method does not require you to indicate the next tile on the board.
    /// </summary>
    /// <param name="n">The name of the tile.</param>
    public Tile(String n)
    {
        tileName = n;
    }

    /// <summary>
    /// Gets the name of the tile.
    /// </summary>
    /// <returns>String.</returns>
    public String GetName()
    {
        return tileName;
    }

    /// <summary>
    /// Gets the next tile.
    /// </summary>
    /// <returns>Tile[].</returns>
    public Tile[] GetNextTile()
    {
        return nextTile;
    }

    /// <summary>
    /// Determines whether this instance is purchasable.
    /// </summary>
    /// <returns><c>true</c> if this instance is purchasable; otherwise, <c>false</c>. In this case always false.</returns>
    public bool IsPurchasable()
    {
        return false;
    }
}
