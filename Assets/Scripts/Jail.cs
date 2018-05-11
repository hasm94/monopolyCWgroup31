// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-09-2018
// ***********************************************************************
// <summary>Class to represent the Jail tile</summary>
// ***********************************************************************
/// <summary>
/// Class Jail.
/// </summary>
internal class Jail : Tile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Jail"/> class.
    /// </summary>
    /// <param name="n">The name of the tile</param>
    public Jail(string n) : base(n)
    {
    }

    /// <summary>
    /// Completes the action. Which is empty in this case, to maintain method consistency, since nothing happens when the player is simply visiting.
    /// </summary>
    /// <param name="p">The player on the tile</param>
    public void CompleteAction(Player p)
    {

    }
}