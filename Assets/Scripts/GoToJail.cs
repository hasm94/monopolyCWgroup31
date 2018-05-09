internal class GoToJail : Tile
{
    public GoToJail(string n) : base(n)
    {
    }

    public void CompleteAction(Player p)
    {
        p.GoesToJail();

    }

}