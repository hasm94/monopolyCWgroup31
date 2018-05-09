internal class PotLuck : Tile
{
    public PotLuck(string n) : base(n)
    {
    }

    public void CompleteAction(Player p)
    {
        CardPiles.TakePLCard(p);
    }
}