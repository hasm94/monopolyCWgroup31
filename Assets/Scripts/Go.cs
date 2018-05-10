internal class Go : NonPurchasable
{
    public Go(string n) : base(n)
    {
    }

    public void CompleteAction(Player p)
    {
        p.Earns(200);
    }
}