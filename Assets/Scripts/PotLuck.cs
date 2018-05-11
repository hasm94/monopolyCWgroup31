// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-09-2018
// ***********************************************************************
// <summary>Represents the PotLuck tiles on the board</summary>
// ***********************************************************************
/// <summary>
/// Class PotLuck.
/// </summary>
internal class PotLuck : Tile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PotLuck"/> class.
    /// </summary>
    /// <param name="n">The name.</param>
    public PotLuck(string n) : base(n)
    {
    }

    /// <summary>
    /// Completes the action.
    /// </summary>
    /// <param name="p">The player drawing the card.</param>
    public void CompleteAction(Player p)
    {
        CardPiles.TakePLCard(p);
    }
}