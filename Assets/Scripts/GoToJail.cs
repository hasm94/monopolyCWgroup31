// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-09-2018
// ***********************************************************************
// <summary>Go To Jail Tile, simply sends the player to jail when landed on</summary>
// ***********************************************************************
/// <summary>
/// Class GoToJail.
/// </summary>
internal class GoToJail : Tile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GoToJail"/> class.
    /// </summary>
    /// <param name="n">The name of the tile</param>
    public GoToJail(string n) : base(n)
    {
    }

    /// <summary>
    /// Sends the player to jail
    /// </summary>
    /// <param name="p">The p.</param>
    public void CompleteAction(Player p)
    {
        p.GoesToJail();

    }

}