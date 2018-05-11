// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Represents the go tile</summary>
// ***********************************************************************
/// <summary>
/// Class Go.
/// </summary>
internal class Go : NonPurchasable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Go"/> class.
    /// </summary>
    /// <param name="n">The n.</param>
    public Go(string n) : base(n)
    {
    }

    /// <summary>
    /// Gives the player £200 if they land on it.
    /// </summary>
    /// <param name="p">The p.</param>
    public void CompleteAction(Player p)
    {
        p.Earns(200);
    }
}