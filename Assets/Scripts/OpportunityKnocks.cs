internal class OpportunityKnocks : NonPurchasable
{
    public OpportunityKnocks(string n) : base(n)
    {

    }

    public void CompleteAction(Player p)
    {
        CardPiles.TakeOKCard(p);
    }
}