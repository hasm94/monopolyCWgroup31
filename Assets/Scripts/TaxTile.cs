internal class TaxTile : NonPurchasable
{
    private int taxAmount;

    public TaxTile(string n, int tax) : base(n)
    {
        taxAmount = tax;
    }

    public void CompleteAction(Player p)
    {
        p.Spends(taxAmount);
    }
}