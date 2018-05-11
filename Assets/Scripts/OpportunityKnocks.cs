// ***********************************************************************
// Assembly         : Assembly-CSharp
// Author           : User
// Created          : 05-09-2018
//
// Last Modified By : User
// Last Modified On : 05-10-2018
// ***********************************************************************
// <summary>Represents Opportunity Knocks tiles</summary>
// ***********************************************************************
/// <summary>
/// Class OpportunityKnocks.
/// </summary>
internal class OpportunityKnocks : NonPurchasable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OpportunityKnocks"/> class.
    /// </summary>
    /// <param name="n">The name of the tile</param>
    public OpportunityKnocks(string n) : base(n)
    {

    }

    /// <summary>
    /// Completes the action.
    /// </summary>
    /// <param name="p">The player that landed on the tile.</param>
    public void CompleteAction(Player p)
    {
        CardPiles.TakeOKCard(p);
    }
}