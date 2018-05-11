// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-09-2018
// ***********************************************************************
// <summary>Tile class to represent the tiles where the player automatically has to pay taxes.</summary>
// ***********************************************************************
/// <summary>
/// Class TaxTile.
/// </summary>
internal class TaxTile : NonPurchasable
{
    /// <summary>
    /// The amount that is taxed when a player lands on the tile.
    /// </summary>
    private int taxAmount;

    /// <summary>
    /// Initializes a new instance of the <see cref="TaxTile"/> class.
    /// </summary>
    /// <param name="n">The name of the tile.</param>
    /// <param name="tax">The amount of tax.</param>
    public TaxTile(string n, int tax) : base(n)
    {
        taxAmount = tax;
    }

    /// <summary>
    /// Makes the player pay the amount of tax.
    /// </summary>
    /// <param name="p">The player.</param>
    public void CompleteAction(Player p)
    {
        p.Spends(taxAmount);
    }
}