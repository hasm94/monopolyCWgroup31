// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>The set of properties that make up a street, with some extra information</summary>
// ***********************************************************************
using UnityEngine;

/// <summary>
/// Class Street.
/// </summary>
public class Street
{

    /// <summary>
    /// The street's colour (includes transport and utility)
    /// </summary>
    public Colour streetColour;
    /// <summary>
    /// The no of properties on the street (ranges from 2-4)
    /// </summary>
    private int noOfProperties;
    /// <summary>
    /// A list of the properties
    /// </summary>
    private Purchasable[] properties = new Purchasable[4];
    /// <summary>
    /// The Cost of a house on the street, if applicable
    /// </summary>
    private int houseCost;


    /// <summary>
    /// Initializes a new instance of the <see cref="Street"/> class.
    /// </summary>
    /// <param name="col">The colour of the street.</param>
    /// <param name="cHouse">The cost of a house.</param>
    public Street(Colour col, int cHouse)
    {
        streetColour = col;
        houseCost = cHouse;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Street"/> class.
    /// </summary>
    /// <param name="col">The colour of the street.</param>
    public Street(Colour col)
    {
        streetColour = col;
    }

    /// <summary>
    /// Adds the property.
    /// </summary>
    /// <param name="pur">The property that is meant to be added to the street</param>
    public void AddProperty(Purchasable pur)
    {
        if (noOfProperties == 5)
        {
            Debug.Log("There are too many properties in this street, check your code");
        }
        else
        {
            properties[noOfProperties] = pur;
            noOfProperties++;
        }

    }

    /// <summary>
    /// Returns the cost of houses that can be built on the street.
    /// </summary>
    /// <returns>System.Int32.</returns>
    public int GetHouseCost()
    {
        return houseCost;
    }

    /// <summary>
    /// Checks if the player owns all of the properties in this street.
    /// </summary>
    /// <param name="player">The player</param>
    /// <returns><c>true</c> if the player owns all of the properties in the street, <c>false</c> otherwise.</returns>
    public bool CheckIfOwned(Player player)
    {
        for (int i = 0; i < noOfProperties; i++)
        {
            if (player != properties[i].GetOwner())
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Gets the colour of the street.
    /// </summary>
    /// <returns>Colour.</returns>
    public Colour GetColour()
    {
        return streetColour;
    }



}
